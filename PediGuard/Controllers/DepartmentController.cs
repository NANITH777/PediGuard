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

        [HttpPost]
        public IActionResult Create(Department obj)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Department created successfully";
            }
                
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display order can not exactly match with the Name");
            //}
            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.Department.Add(obj);
            //    _unitOfWork.Save();
            //    TempData["success"] = "Department created successfully";
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Department? departmentFromDb = _db.Departments.Find(id);

            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Department obj)
        {

            if (ModelState.IsValid)
            {
                _db.Departments.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Department updated successfully";
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

            Department? departmentFromDb = _db.Departments.Find(id);

            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Department? obj = _db.Departments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Departments.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Department deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
