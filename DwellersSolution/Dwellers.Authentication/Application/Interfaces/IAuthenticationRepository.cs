using Dwellers.Authentication.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Authentication.Application.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<DbUser> GetUserByEmail(string email);
        Task<DbUser> GetUserById(string id);
        Task<SignInResult> CheckLoginCredentials(string username, string password);
    }
}
