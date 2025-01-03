﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPlannerDb;
using SmartPlanner.Helpers;
using SmartPlannerDb.Entities;
using SmartPlanner.Models;

namespace SmartPlanner.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProjectsStorage _prjectStorage;
        private readonly INotesStorage _notesStorage;
        private readonly IGoalsStorage _goalsStorage;
        private readonly ITasksStorage _taskStorage;

        public ProjectsController(IProjectsStorage projectsStorage, INotesStorage notesStorage, IGoalsStorage goalsStorage, ITasksStorage taskStorage, UserManager<User> userManager)
        {
            _prjectStorage = projectsStorage;
            _notesStorage = notesStorage;
            _goalsStorage = goalsStorage;
            _taskStorage = taskStorage;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(this.User);
            var projects = await _prjectStorage.GetAllAsync(userId);
            var projectsVM = projects.ToViewModel();
            return View(projectsVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            var userId = _userManager.GetUserId(this.User);
            model.UserId = userId;
            var modelDB = model.ToDbModel();
            await _prjectStorage.AddAsync(modelDB);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id, string tab)
        {
            var userId = _userManager.GetUserId(this.User);
            var project = await _prjectStorage.GetAsync(id);
            var projectVM = project.ToViewModel();
            ViewData["ActiveTab"] = tab ?? "Tasks"; // Установите вкладку по умолчанию
            return View(projectVM);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _prjectStorage.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
