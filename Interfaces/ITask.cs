using System.Security.Claims;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Interfaces
{
    public interface ITask
    {
        public bool Add(AppTask appTask);
        public bool Remove(AppTask appTask);
        public bool Update(AppTask appTask);
        public bool Change(AppTask new_task);//for future
        public Task<AppTask> GetTaskByIDAsync(int id);
        public bool Save();
        public List<AppTask> GetAllTasksByUserId(string UserId);
    }
}
