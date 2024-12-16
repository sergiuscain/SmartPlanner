using Microsoft.AspNetCore.Mvc;
using SmartPlanner.Models;
using SmartPlanner.Services;
using SmartPlanner.TestData;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            var notes = DataForTesting.Notes;
            return View(notes);
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
