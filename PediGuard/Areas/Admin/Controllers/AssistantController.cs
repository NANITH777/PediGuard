using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PediGuard.Helper;
using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AssistantController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public AssistantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Assistant> objAssistantList = _unitOfWork.Assistant.GetAll().ToList();
            return View(objAssistantList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assistant obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Assistant.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Assistant created successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Assistant? assistantFromDb = _unitOfWork.Assistant.Get(u => u.Id == id);

            if (assistantFromDb == null)
            {
                return NotFound();
            }
            return View(assistantFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Assistant obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Assistant.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Assistant updated successfully";
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

            Assistant? assistantFromDb = _unitOfWork.Assistant.Get(u => u.Id == id);

            if (assistantFromDb == null)
            {
                return NotFound();
            }
            return View(assistantFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Assistant? obj = _unitOfWork.Assistant.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Assistant.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Assistant deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
