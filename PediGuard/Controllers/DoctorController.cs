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
    }
}
