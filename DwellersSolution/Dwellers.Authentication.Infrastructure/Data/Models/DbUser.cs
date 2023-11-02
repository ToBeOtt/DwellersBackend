using Microsoft.AspNetCore.Identity;

namespace Dwellers.Authentication.Infrastructure.Data.Models
{
    public sealed class DbUser : IdentityUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Alias { get; set; }

        public DbUser() { }

        public DbUser(string email, string username, string alias)
        {
            Email = email;
            UserName = username;
            Alias = alias;
        }

    }
}
