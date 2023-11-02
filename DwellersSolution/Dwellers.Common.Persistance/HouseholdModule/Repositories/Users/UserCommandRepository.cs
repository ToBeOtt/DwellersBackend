using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;

namespace Dwellers.Common.Persistance.HouseholdModule.Repositories.Users
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly DwellerDbContext _context;

        public UserCommandRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(DwellerUserEntity user)
        {
            var result = _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(DwellerUserEntity User)
        {
            var result = _context.Users.Update(User);
            await _context.SaveChangesAsync();
            return false;
        }
    }
}
