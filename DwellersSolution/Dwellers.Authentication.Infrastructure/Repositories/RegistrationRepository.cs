using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Domain;
using Dwellers.Authentication.Infrastructure.Data;
using Dwellers.Authentication.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Dwellers.Authentication.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<DbUser> _userManager;

        public RegistrationRepository(AuthDbContext context, UserManager<DbUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(DwellerUser user, string password)
        {
            var dbUser = new DbUser(user.Email, user.Email, user.Alias);

            var result = await _userManager.CreateAsync(dbUser, password);
            if (result.Succeeded)
            {
                _context.SaveChanges();
                return result;
            }
            return result;
        }

        public async Task<bool> CheckNoUserExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
