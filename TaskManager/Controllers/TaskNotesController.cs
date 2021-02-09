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
            if (ModelState.IsValid)
            {
                _db.TaskNotes.Add(taskNote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskNote);
        }
        //GET-EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _db.TaskNotes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskNote taskNote)
        {
            if (ModelState.IsValid)
            {
                _db.TaskNotes.Update(taskNote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskNote);
        }

        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskNote = _db.TaskNotes.Find(id);
            
            if (taskNote == null)
            {
                return NotFound();
            }
            return View(taskNote);
        }
        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var taskNote = _db.TaskNotes.Find(id);
            if (taskNote == null)
            {
                return NotFound();
            }

            _db.TaskNotes.Remove(taskNote);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
