using Dwellers.Authentication.Infrastructure.Data;

namespace Dwellers.Authentication.Infrastructure.Repositories
{
    public class AuthenticationRepository
    {
        private readonly AuthDbContext _context;

        public AuthenticationRepository(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<bool> GetUserByEmail(string email)
        {
            //return _context.Users.Where(u => u.Email == email).SingleOrDefault();
            return true;
        }

        public async Task<bool> GetUserById(string id)
        {
            //return _context.Users.Where(u => u.Id == id).SingleOrDefault();
            return true;
        }

        public async Task<bool> CheckLoginCredentials(string username, string password)
        {
            //return await _signInManager.PasswordSignInAsync(username, password, false, false);
            return true;
        }
    }
}
