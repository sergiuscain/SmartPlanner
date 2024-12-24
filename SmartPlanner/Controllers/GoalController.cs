using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPlanner.Helpers;
using SmartPlannerDb;
using SmartPlannerDb.Entities;

namespace SmartPlanner.Controllers
{
    public class GoalController : Controller
    {
        private readonly IGoalsStorage _storage;
        private readonly UserManager<User> _userManager;
        Random random = new Random();
        public GoalController(IGoalsStorage storage, UserManager<User> userManager)
        {
            _storage = storage;
            _userManager = userManager;
        }
        // GET: GoalController
        public async Task<ActionResult> Index()
        {
            string userId = _userManager.GetUserId(this.User);
            var goals = await _storage.GetAllAsync(userId);
            var goalsVM = goals.ToViewModel();
            return View(goalsVM);
        }

        // GET: GoalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GoalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GoalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GoalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GoalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GoalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> CreateTest()
        {
            int totalPr = random.Next(10000);
            int current = random.Next(totalPr);
            string userId = _userManager.GetUserId(this.User);
            var testGoal = new Goal
            {
                Description = "2 000 000 отжиманий за раз",
                CurrentProgress = current,
                TotalProgress = totalPr,
                UserId = userId,
            };
            await _storage.AddAsync(testGoal);
            return RedirectToAction("Index");
        }
    }
}
