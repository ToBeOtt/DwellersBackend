using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Application.Interfaces.Users;

namespace Dwellers.Household.Infrastructure.Repositories.Users
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
