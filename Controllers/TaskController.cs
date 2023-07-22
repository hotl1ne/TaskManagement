using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApp.Data;
using WebApp.Models;
using WebApp.Repository;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbConextcs _context;
        private readonly TaskRepository _taskRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public TaskController(AppDbConextcs context, TaskRepository taskRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _taskRepository = taskRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TaskViewModel task)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var new_task = new AppTask
                    {
                        TaskName = task.TaskName,
                        TaskDescription = task.TaskDescription,
                        TaskStatus = false,
                        AppUserId = user.Id
                    };
                    if (_taskRepository.Add(new_task))
                    {
                        return View("Add");
                    }
                }
            }
            return View(task);
        }
        [HttpPost]
        public async Task<IActionResult> Complete(int taskID)
        {
            var appTask = await _taskRepository.GetTaskByIDAsync(taskID);
            if (appTask != null)
            {
                appTask.TaskStatus = true;
                _taskRepository.Update(appTask);
            }
            return RedirectToAction("Show");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int taskID)
        {
            var appTask = await _taskRepository.GetTaskByIDAsync(taskID);
            if (appTask != null)
            {
                _taskRepository.Remove(appTask);
            }
            return RedirectToAction("Show");
        }
        [HttpGet]
        public async Task<IActionResult> Show()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user != null)
            {
                var tasks = _taskRepository.GetAllTasksByUserId(user.Id);
                return View(tasks);
            }
            return NotFound();
        }

    }
}
