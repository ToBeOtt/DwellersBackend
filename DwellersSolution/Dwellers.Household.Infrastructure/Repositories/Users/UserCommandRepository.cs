using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Infrastructure.Repositories.Users
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserCommandRepository(HouseholdDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                _context.SaveChanges();
                return result;
            }
            return result;
        }

        public async Task<bool> AddMemberRole(User user)
        {
            await _userManager.AddToRoleAsync(user, "HouseMember");
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> AddOwnerRole(User user)
        {
            await _userManager.AddToRoleAsync(user, "HouseOwner");
            _context.SaveChanges();
            return true;
        }

        
    }
}
