using Microsoft.AspNetCore.Mvc;

namespace SmartPlanner.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
