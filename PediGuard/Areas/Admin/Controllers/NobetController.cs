using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PediGuard.Models;
using PediGuard.Models.ViewModels;
using PediGuard.Repository.IRepository;
using System.Runtime.InteropServices;

namespace PediGuard.Areas.Admin.Controllers
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
           .GetAll(includeProperties: "Assistant,Department")
           .ToList();
            return View(objNobetList);
        }


        public IActionResult Upsert(int? id)
        {
            // Create NobetVM object
            NobetVM nobetVM = new()
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

                // Initialize a new Nobet object
                Nobet = new Nobet()
            };

            // If the ID is null or 0, it's a new record creation
            if (id == null || id == 0)
            {
                return View(nobetVM);
            }
            else
            {
                nobetVM.Nobet = _unitOfWork.Nobet.Get(u => u.ID == id, includeProperties: "Assistant,Department");
                return View(nobetVM);
            }
        }

        

        [HttpPost]
        public IActionResult Upsert(NobetVM nobetVM)
        {
            if (ModelState.IsValid)
            {
                if (nobetVM.Nobet.ID == 0)
                {
                    _unitOfWork.Nobet.Add(nobetVM.Nobet);  // Add new record if ID is 0
                }
                else
                {
                    _unitOfWork.Nobet.Update(nobetVM.Nobet);
                }

                _unitOfWork.Save();  // Save changes to the database

                TempData["success"] = "Nobet created/updated successfully!";
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

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Nobet> objNobetList = _unitOfWork.Nobet
            .GetAll(includeProperties: "Assistant,Department")
            .ToList();
            return Json(new { data = objNobetList });
        }

        [HttpDelete]
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

        //public IActionResult DeletePost(int? id)
        //{
        //    Nobet? obj = _unitOfWork.Nobet.Get(u => u.ID == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Nobet.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Nobet deleted successfully";
        //    return RedirectToAction("Index");
        //}
        #endregion
    }
}
