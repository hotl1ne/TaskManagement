using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IUser
    {
        public bool Add(AppUser appUser);
        public bool Remove(AppUser appUser);
        public Task<AppUser> GetUserByIDAsync(int id);
    }
}
