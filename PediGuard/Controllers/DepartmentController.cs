using Microsoft.AspNetCore.Mvc;
using PediGuard.Models;

namespace PediGuard.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Department> objDepartmentList = _db.Departments.ToList();
            return View(objDepartmentList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
