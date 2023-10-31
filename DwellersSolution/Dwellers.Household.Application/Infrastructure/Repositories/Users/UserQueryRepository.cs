using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Common.DAL.Services.Interfaces;
using Dwellers.Household.Application.Interfaces.Users;

namespace Dwellers.Household.Infrastructure.Repositories.Users
{
    public class UserQueryRepository : IUserQueryRepository, ICommonUserServices
    {
        private readonly DwellerDbContext _context;

        public UserQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<DwellerUserEntity> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).SingleOrDefault();
        }

        public async Task<DwellerUserEntity> GetUserById(string id)
        {
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<bool> CheckLoginCredentials(string username, string password)
        {
            return true;
        }

        public async Task<DwellerUserEntity> GetUserForOtherServicesById(string userId)
        {
            return _context.Users.Where(u => u.Id == userId).SingleOrDefault();
        }
    }
}
