using Dwellers.Household.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Application.Interfaces.Users;

namespace Dwellers.Household.Infrastructure.Repositories.Users
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly HouseholdDbContext _context;
        private readonly UserManager<DwellerUser> _userManager;

        public UserCommandRepository(HouseholdDbContext context, UserManager<DwellerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(DwellerUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                _context.SaveChanges();
                return result;
            }
            return result;
        }

        public async Task<bool> AddMemberRole(DwellerUser user)
        {
            await _userManager.AddToRoleAsync(user, "HouseMember");
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> AddOwnerRole(DwellerUser user)
        {
            await _userManager.AddToRoleAsync(user, "HouseOwner");
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateUser(DwellerUser User)
        {
            var result = await _userManager.UpdateAsync(User);
            if (result.Succeeded)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
