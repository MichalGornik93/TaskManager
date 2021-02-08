using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskNotesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TaskNotesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TaskNote> taskNotes = _db.TaskNotes;
            return View(taskNotes);
        }
        //GET-CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskNote taskNote)
        {
            if(ModelState.IsValid)
            {
                _db.TaskNotes.Add(taskNote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskNote);
            
        }
    }
}
