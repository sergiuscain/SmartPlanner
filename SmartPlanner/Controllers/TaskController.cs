using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPlanner.Helpers;
using SmartPlanner.Models;
using SmartPlannerDb;
using SmartPlannerDb.Entities;

namespace SmartPlanner.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasksStorage _storage;
        private readonly UserManager<User> _userManager;
        public TaskController(ITasksStorage storage, UserManager<User> userManager)
        {
            _storage = storage;
            _userManager = userManager;
        }

        public async Task<IActionResult> InProgress() //InProgress ведёт на вкладку "В работе"
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _storage.GetByStatusAsync(userId, Status.InProgress.ToString());
            var tasksVM = tasks.ToViewModel();
            return View("Index", tasksVM);
        }
        public async Task<IActionResult> Pending() //Pending ведёт на вкладку "В ожидании"
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _storage.GetByStatusAsync(userId, Status.Pending.ToString());
            var tasksVM = tasks.ToViewModel();
            return View("Index", tasksVM);
        }
        public async Task<IActionResult> InTesting() //InTesting ведёт на вкладку "В тестировании"
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _storage.GetByStatusAsync(userId, Status.InTesting.ToString());
            var tasksVM = tasks.ToViewModel();
            return View("Index", tasksVM);
        }
        public async Task<IActionResult> Done() //Done ведёт на вкладку "Выполнено"
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _storage.GetByStatusAsync(userId, Status.Done.ToString());
            var tasksVM = tasks.ToViewModel();
            return View("Index", tasksVM);
        }
            public async Task<IActionResult> Review() //Review ведёт на вкладку, где все статусы на одной странице
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _storage.GetAllAsync(userId);
            var tasksVM = tasks.ToViewModel();
            return View("Review", tasksVM);
        }
        public async Task<IActionResult> Task(Guid id)
        {
            var task = await _storage.GetByIdAsync(id);
            if (task != null)
            {
                return View(task.ToViewModel());
            } 
            return View("NotFound");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskViewModel model)
        {
            var userId = _userManager.GetUserId(this.User);
            model.TaskModelId = Guid.NewGuid();
            model.UserId = userId;
            model.DateOfCreation = DateTime.Now;
            var task = model.ToDbModel();
            await _storage.AddAsync(task);
            return RedirectToAction(model.Status);
        }
        public async Task<IActionResult> EditStatus(Guid taskId, string newStatus)
        {
            var lastAction = Request.Headers["Referer"].ToString().Split('/').Last();
            string lastStatus = await _storage.GetStatusByIdAsync(taskId);
            await _storage.EditStatusAsync(taskId, newStatus);
            return RedirectToAction(lastAction);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _storage.DeleteAsync(id);
            return RedirectToAction("Review");
        }
    }
}
