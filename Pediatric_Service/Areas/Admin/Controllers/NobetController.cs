using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pediatric_Service.Models.ViewModels;
using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;
using Pediatric_Service.Helper;

namespace Pediatric_Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NobetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NobetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Nobet> objNobetList = _unitOfWork.Nobet
           .GetAll(includeProperties: "Doctor,Department")
           .ToList();
            return View(objNobetList);
        }

        public IActionResult Available()
        {
            var availableNobets = _unitOfWork.Nobet
            .GetAll(n => !n.Appointments.Any(a => a.Status != AppointmentStatus.Cancelled), includeProperties: "Doctor,Department")
            .OrderBy(n => n.Date)
            .ToList();

            return View(availableNobets);
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Upsert(int? id)
        {
            // Create NobetVM object
            NobetVM nobetVM = new()
            {
                // Fetch the list of assistants for the dropdown
                DoctorList = _unitOfWork.Doctor.GetAll().Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }),

                // Fetch the list of departments for the dropdown
                DepartmentList = _unitOfWork.Department.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }),

                // Initialize a new Nobet object
                Nobet = new Nobet()
            };

            // If the ID is null or 0, it's a new record creation
            if (id == null || id == 0)
            {
                nobetVM.Nobet.Date = DateTime.Now.Date;
                nobetVM.Nobet.StartTime = DateTime.Now; 
                nobetVM.Nobet.EndTime = DateTime.Now.AddMinutes(30); 
                return View(nobetVM);
            }
            else
            {
                nobetVM.Nobet = _unitOfWork.Nobet.Get(u => u.ID == id);
                return View(nobetVM);
            }
        }


        [HttpPost]
        public IActionResult Upsert(NobetVM nobetVM)
        {
            // Check for overlapping time slots for the same doctor
            var existingNobets = _unitOfWork.Nobet.GetAll()
                .Where(n => n.DoctorID == nobetVM.Nobet.DoctorID &&
                            n.Date.Date == nobetVM.Nobet.Date.Date &&
                            n.ID != nobetVM.Nobet.ID)
                .ToList();

            bool hasOverlap = existingNobets.Any(existingNobet =>
                // Check time overlaps
                (nobetVM.Nobet.StartTime >= existingNobet.StartTime &&
                 nobetVM.Nobet.StartTime < existingNobet.EndTime) ||
                (nobetVM.Nobet.EndTime > existingNobet.StartTime &&
                 nobetVM.Nobet.EndTime <= existingNobet.EndTime) ||
                (nobetVM.Nobet.StartTime <= existingNobet.StartTime &&
                 nobetVM.Nobet.EndTime >= existingNobet.EndTime));

            if (hasOverlap)
            {
                ModelState.AddModelError("", "This time slot overlaps with an existing slot for this doctor on the same date.");
            }

            if (ModelState.IsValid)
            {
                if (nobetVM.Nobet.ID == 0)
                {
                    _unitOfWork.Nobet.Add(nobetVM.Nobet);
                }
                else
                {
                    _unitOfWork.Nobet.Update(nobetVM.Nobet);
                }
                _unitOfWork.Save();
                TempData["success"] = "Time slot created/updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                // Repopulate the dropdown lists if validation fails
                nobetVM.DoctorList = _unitOfWork.Doctor.GetAll().Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                });
                nobetVM.DepartmentList = _unitOfWork.Department.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                return View(nobetVM);
            }
        }

        public IActionResult Calendar()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Nobet> objNobetList = _unitOfWork.Nobet
            .GetAll(includeProperties: "Doctor,Department")
            .ToList();
            return Json(new { data = objNobetList });
        }

        [HttpDelete]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new { success = false, message = "ID is required" });
            }

            var NobetToBeDeleted = _unitOfWork.Nobet.Get(u => u.ID == id);

            if (NobetToBeDeleted == null)
            {
                return NotFound(new { success = false, message = "Record not found" });
            }

            _unitOfWork.Nobet.Remove(NobetToBeDeleted);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Delete successful" });
        }

        [HttpGet]
        public IActionResult GetAllNobet()
        {
            try
            {
                var nobetList = _unitOfWork.Nobet.GetAll(includeProperties: "Doctor,Department")
                    .Select(n => new
                    {
                        id = n.ID,
                        title = $"{n.Doctor?.FullName ?? "Unknown"} - {n.Department?.Name ?? "Unknown"}",
                        start = n.Date.Add(n.StartTime.TimeOfDay).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                        end = n.Date.Add(n.EndTime.TimeOfDay).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                        DoctorName = n.Doctor?.FullName ?? "Unknown",
                        departmentName = n.Department?.Name ?? "Unknown",
                        color = GetColorForDepartment(n.Department?.Name)
                    })
                    .ToList();

                return Json(nobetList);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "Error retrieving Nobet data", details = ex.Message });
            }
        }

        private string GetColorForDepartment(string departmentName)
        {
            return departmentName switch
            {
                "Pediatric Emergency" => "#FF6B6B",
                "Pediatric Intensive Care" => "#4ECDC4",
                "Pediatric Hematology and Oncology" => "#45B7D1",
                "Neonatology" => "#FFA500",
                "General Pediatrics" => "#6A5ACD",
                "Pediatric Pulmonology" => "#FF6347",
                "Pediatric Cardiology" => "#FFD700",
                "Pediatric Neurology" => "#32CD32",
                "Pediatric Endocrinology" => "#FF4500",
                "Pediatric Gastroenterology" => "#1E90FF",
                "Developmental and Behavioral Pediatrics" => "#FF1493",
                "Pediatric Rheumatology" => "#8A2BE2",
                "Pediatric Surgery" => "#7FFF00",
                "Pediatric Dermatology" => "#FF69B4",
                "Pediatric Nephrology" => "#00CED1",
                _ => "#6A5ACD"
            };
        }
        #endregion
    }
}
