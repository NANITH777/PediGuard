using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pediatric_Service.Helper;
using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Doctor> objDoctorList = _unitOfWork.Doctor.GetAll().ToList();
            return View(objDoctorList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Doctor.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Doctor created successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Doctor? doctorFromDb = _unitOfWork.Doctor.Get(u => u.Id == id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Doctor obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Doctor.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Doctor updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Doctor? doctorFromDb = _unitOfWork.Doctor.Get(u => u.Id == id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Doctor? obj = _unitOfWork.Doctor.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Doctor.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Doctor deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
