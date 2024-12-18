using Microsoft.AspNetCore.Mvc;
using SmartPlanner.Models;
using SmartPlanner.Services;
using SmartPlanner.TestData;
using System.Diagnostics;
using SmartPlanner.Helpers;
using SmartPlannerDb;

namespace SmartPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotesStorage _storage;
        public HomeController(ILogger<HomeController> logger, INotesStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var notes = await _storage.GetAllTestMethodAsync();
            var notesVm = notes.ToViewModel();
            return View(notesVm);
        }

        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _storage.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create(NoteViewModel note)
        {
            var noteDb = note.ToDbModel();
            await _storage.AddAsync(noteDb);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Note(Guid id)
        {
            var note = await _storage.GetByIdAsync(id);
            var noteVm = note.ToViewModel();
            return View(noteVm);
        }
        public async Task<IActionResult> Update(NoteViewModel note)
        {
            var noteDb = note.ToDbModel();
            await _storage.UpdateAsync(noteDb);
            return RedirectToAction("Note", note);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
