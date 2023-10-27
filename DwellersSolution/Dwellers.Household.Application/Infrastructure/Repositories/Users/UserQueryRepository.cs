using Dwellers.Household.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Application.Interfaces.Users;

namespace Dwellers.Household.Infrastructure.Repositories.Users
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly SignInManager<DwellerUser> _signInManager;

        public UserQueryRepository(
                HouseholdDbContext context, 
                SignInManager<DwellerUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<DwellerUser?> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).SingleOrDefault(); 
        }

        public async Task<DwellerUser?> GetUserById(string id)
        {
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<SignInResult> CheckLoginCredentials(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }
    }
}
