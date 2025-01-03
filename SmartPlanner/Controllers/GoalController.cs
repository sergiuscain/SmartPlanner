using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPlanner.Helpers;
using SmartPlanner.Models;
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

        // GET: GoalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GoalViewModel goal)
        {
            var userId = _userManager.GetUserId(this.User);
            goal.UserId = userId;
            var goalDB = goal.ToDbModel();
            await _storage.AddAsync(goalDB);
            return RedirectToAction("Index");
        }
        public ActionResult CreateForProject(Guid projectId)
        {
            var viewModel = new GoalViewModel { ProjectId = projectId };
            return View(viewModel);
        }

        // POST: GoalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateForProject(GoalViewModel goal)
        {
            var userId = _userManager.GetUserId(this.User);
            goal.UserId = userId;
            var goalDB = goal.ToDbModel();
            await _storage.AddAsync(goalDB);
            return RedirectToAction("Details", "Projects", new {id = goal.ProjectId, tab = "Goals" });
        }

        // GET: GoalController/Edit/5
        public ActionResult Edit(GoalViewModel goal)
        {
            return View(goal);
        }

        // POST: GoalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editing(GoalViewModel goal)
        {
            var goalDb = goal.ToDbModel();
            await _storage.EditAsync(goalDb);
            if (goal.ProjectId != null)
                return RedirectToAction("Details", "Projects", new { id = goal.ProjectId, tab = "Goals" });
            return RedirectToAction("Index");
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
        public async Task<ActionResult> Delete(Guid id)
        {
            var goal = await _storage.GetByIdAsync(id);
            await _storage.DeleteAsync(id);
            if (goal.ProjectId != null)
                return RedirectToAction("Details", "Projects", new { id = goal.ProjectId, tab = "Goals" });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddPoints(Guid id, int points)
        {
            await _storage.AddPointsAsync(id, points);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddPointsForProjects(Guid id, int points, Guid projectId)
        {
            await _storage.AddPointsAsync(id, points);
            return RedirectToAction("Details", "Projects", new { id = projectId, tab = "Goals" });
        }
    }
}