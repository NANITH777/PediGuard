using Microsoft.AspNetCore.Mvc;
using PediGuard.Models;
using PediGuard.Repository.IRepository;

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
            List<Nobet> objNobetList = _unitOfWork.Nobet.GetAll().ToList();
            return View(objNobetList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nobet obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Nobet.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nobet created successfully";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Nobet? nobetFromDb = _unitOfWork.Nobet.Get(u => u.ID == id);

            if (nobetFromDb == null)
            {
                return NotFound();
            }
            return View(nobetFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Nobet obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Nobet.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nobet updated successfully";
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

            Nobet? nobetFromDb = _unitOfWork.Nobet.Get(u => u.ID == id);

            if (nobetFromDb == null)
            {
                return NotFound();
            }
            return View(nobetFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Nobet? obj = _unitOfWork.Nobet.Get(u => u.ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Nobet.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Nobet deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
