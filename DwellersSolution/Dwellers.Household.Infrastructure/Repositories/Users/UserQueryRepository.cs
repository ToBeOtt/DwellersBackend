using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Infrastructure.Repositories.Users
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public UserQueryRepository(
                HouseholdDbContext context, 
                SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).SingleOrDefault(); 
        }

        public async Task<User?> GetUserById(string id)
        {
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<SignInResult> CheckLoginCredentials(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }
    }
}
