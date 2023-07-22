using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Repository
{
    public class UserReposiroty : IUser
    {
        private readonly AppDbConextcs _context;
        public UserReposiroty(AppDbConextcs context)
        {
            _context = context;
        }
        public bool Add(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUserByIDAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Remove(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
