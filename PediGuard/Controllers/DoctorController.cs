using Microsoft.AspNetCore.Mvc;
using PediGuard.Models;

namespace PediGuard.Controllers
{
    public class DoctorController : Controller
    {
       private readonly ApplicationDbContext _db;
        public DoctorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Doctor> objDoctorList = _db.Doctors.ToList();
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
                _db.Doctors.Add(obj);
                _db.SaveChanges();
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

            Doctor? doctorFromDb = _db.Doctors.Find(id);

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
                _db.Doctors.Update(obj);
                _db.SaveChanges();
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

            Doctor? doctorFromDb = _db.Doctors.Find(id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Doctor? obj = _db.Doctors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Doctors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Doctor deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
