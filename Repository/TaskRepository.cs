using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Repository
{
    public class TaskRepository : ITask
    {
        private readonly AppDbConextcs context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public TaskRepository(AppDbConextcs appDbConextcs, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) 
        {
            context= appDbConextcs;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public bool Add (AppTask AppTask)
        { 
            context.Add(AppTask);
            return Save();
        }

        public bool Remove (AppTask task)
        {
            context.Remove(task);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Change (AppTask new_task)//for future
        {
            context.Update(new_task);
            return Save();
        }
        public List<AppTask> GetAllTasksByUserId(string UserId)
        {
            List<AppTask> tasks = context.appTasks.Where(t => t.AppUserId == UserId).ToList();
            return tasks;
        }

        public async Task<AppTask> GetTaskByIDAsync(int id) 
        {
            return await context.appTasks.FirstOrDefaultAsync(i => i.TaskID == id);
        }

        public bool Update(AppTask appTask)
        {
            context.Update(appTask);
            return Save();
        }
    }
}
