using Microsoft.AspNetCore.Mvc;
using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Department> objDepartmentList = _unitOfWork.Department.GetAll().ToList();
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
                _unitOfWork.Department.Add(obj);
                _unitOfWork.Save();
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

            Department? departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);

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
                _unitOfWork.Department.Update(obj);
                _unitOfWork.Save();
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

            Department? departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);

            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Department? obj = _unitOfWork.Department.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Department deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
