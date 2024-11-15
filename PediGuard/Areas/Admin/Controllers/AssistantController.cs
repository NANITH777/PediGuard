using Microsoft.AspNetCore.Mvc;
using PediGuard.Models;

namespace PediGuard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssistantController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        public AssistantController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Assistant> objAssistantList = _db.Assistants.ToList();
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
                _db.Assistants.Add(obj);
                _db.SaveChanges();
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

            Assistant? assistantFromDb = _db.Assistants.Find(id);

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
                _db.Assistants.Update(obj);
                _db.SaveChanges();
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

            Assistant? assistantFromDb = _db.Assistants.Find(id);

            if (assistantFromDb == null)
            {
                return NotFound();
            }
            return View(assistantFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Assistant? obj = _db.Assistants.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Assistants.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Assistant deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
