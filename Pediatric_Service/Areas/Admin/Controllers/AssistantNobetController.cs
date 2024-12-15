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
    public class AssistantNobetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssistantNobetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<AssistantNobet> objAssistantNobetList = _unitOfWork.AssistantNobet
           .GetAll(includeProperties: "Assistant,Department")
           .ToList();
            return View(objAssistantNobetList);
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Upsert(int? id)
        {
            // Create AssistantNobetVM object
            AssistantNobetVM assistantnobetVM = new()
            {
                // Fetch the list of assistants for the dropdown
                AssistantList = _unitOfWork.Assistant.GetAll().Select(a => new SelectListItem
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

                // Initialize a new AssistantNobet object
                AssistantNobet = new AssistantNobet()
            };

            // If the ID is null or 0, it's a new record creation
            if (id == null || id == 0)
            {
                assistantnobetVM.AssistantNobet.Date = DateTime.Now.Date;
                assistantnobetVM.AssistantNobet.StartTime = DateTime.Now;
                assistantnobetVM.AssistantNobet.EndTime = DateTime.Now.AddMinutes(300); 
                return View(assistantnobetVM);
            }
            else
            {
                assistantnobetVM.AssistantNobet = _unitOfWork.AssistantNobet.Get(u => u.ID == id);
                return View(assistantnobetVM);
            }
        }


        [HttpPost]
        public IActionResult Upsert(AssistantNobetVM nobetVM)
        {
            // Check if the assistant already has a time slot on the same day
            var existingNobetOnSameDay = _unitOfWork.AssistantNobet.GetAll()
                .FirstOrDefault(n => n.AssistantID == nobetVM.AssistantNobet.AssistantID &&
                                     n.Date.Date == nobetVM.AssistantNobet.Date.Date &&
                                     n.ID != nobetVM.AssistantNobet.ID);

            if (existingNobetOnSameDay != null)
            {
                ModelState.AddModelError("", "This assistant already has a time slot on the selected date.");
            }

            if (ModelState.IsValid)
            {
                if (nobetVM.AssistantNobet.ID == 0)
                {
                    _unitOfWork.AssistantNobet.Add(nobetVM.AssistantNobet);
                }
                else
                {
                    _unitOfWork.AssistantNobet.Update(nobetVM.AssistantNobet);
                }
                _unitOfWork.Save();
                TempData["success"] = "AssistantNobet created/updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                // Repopulate the dropdown lists if validation fails
                nobetVM.AssistantList = _unitOfWork.Assistant.GetAll().Select(a => new SelectListItem
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
            List<AssistantNobet> objAssistantNobetList = _unitOfWork.AssistantNobet
            .GetAll(includeProperties: "Assistant,Department")
            .ToList();
            return Json(new { data = objAssistantNobetList });
        }

        [HttpDelete]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new { success = false, message = "ID is required" });
            }

            var AssistantNobetToBeDeleted = _unitOfWork.AssistantNobet.Get(u => u.ID == id);

            if (AssistantNobetToBeDeleted == null)
            {
                return NotFound(new { success = false, message = "Record not found" });
            }

            _unitOfWork.AssistantNobet.Remove(AssistantNobetToBeDeleted);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Delete successful" });
        }

        [HttpGet]
        public IActionResult GetAllAssistantNobet()
        {
            try
            {
                var assistantList = _unitOfWork.AssistantNobet.GetAll(includeProperties: "Assistant,Department")
                    .Select(n => new
                    {
                        id = n.ID,
                        title = $"{n.Assistant?.FullName ?? "Unknown"} - {n.Department?.Name ?? "Unknown"}",
                        start = n.Date.Add(n.StartTime.TimeOfDay).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                        end = n.Date.Add(n.EndTime.TimeOfDay).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                        AssistantName = n.Assistant?.FullName ?? "Unknown",
                        departmentName = n.Department?.Name ?? "Unknown",
                        color = GetColorForDepartment(n.Department?.Name)
                    })
                    .ToList();

                return Json(assistantList);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "Error retrieving AssistantNobet data", details = ex.Message });
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
