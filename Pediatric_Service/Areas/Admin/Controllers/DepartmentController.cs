using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pediatric_Service.Helper;
using Pediatric_Service.Models;
using Pediatric_Service.Models.ViewModels;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Department> objDepartmentList = _unitOfWork.Department
           .GetAll(includeProperties: "Doctor").ToList();
            return View(objDepartmentList);
        }

        public IActionResult Upsert(int? id)
        {
            // Create DepartmentVM object
            DepartmentVM departmentVM = new()
            {
                // Fetch the list of Doctors for the dropdown
                DoctorList = _unitOfWork.Doctor.GetAll().Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }),

                // Initialize a new Department object
                Department = new Department()
            };

            // If the ID is null or 0, it's a new record creation
            if (id == null || id == 0)
            {
                return View(departmentVM);
            }
            else
            {
                departmentVM.Department = _unitOfWork.Department.Get(u => u.Id == id);
                return View(departmentVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                if (departmentVM.Department.Id == 0)
                {
                    _unitOfWork.Department.Add(departmentVM.Department);  // Add new record if ID is 0
                }
                else
                {
                    _unitOfWork.Department.Update(departmentVM.Department);
                }

                _unitOfWork.Save();  // Save changes to the database

                TempData["success"] = "Department created/updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                // Repopulate the dropdown lists if validation fails
                departmentVM.DoctorList = _unitOfWork.Doctor.GetAll().Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                });
                return View(departmentVM);
            }

        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> objDepartmentList = _unitOfWork.Department
            .GetAll(includeProperties: "Doctor")
            .ToList();
            return Json(new { data = objDepartmentList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new { success = false, message = "ID is required" });
            }

            var DepartmentToBeDeleted = _unitOfWork.Department.Get(u => u.Id == id);

            if (DepartmentToBeDeleted == null)
            {
                return NotFound(new { success = false, message = "Record not found" });
            }

            _unitOfWork.Department.Remove(DepartmentToBeDeleted);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
