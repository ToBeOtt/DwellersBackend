using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Dwellers.Authentication.Domain
{
    public sealed class DbUser : IdentityUser
    {
        public string Alias { get; private set; }

        public DbUser() { }

        public DomainResponse CreateUser(string email, string alias)
        {
            DomainResponse domainResponse = new DomainResponse();
            var emailResponse = SetEmail(email);
            if (!emailResponse.IsSuccess) return (emailResponse);

            var aliasResponse = SetAlias(alias);
            if (!aliasResponse.IsSuccess) return (aliasResponse);
            
            domainResponse.IsSuccess = true;
            return domainResponse;
        }

        public DomainResponse SetEmail(string email)
        {
            DomainResponse domainResponse = new DomainResponse();
            if (this.UserName != null && this.UserName != email)
            {
                domainResponse.IsSuccess = false;
                domainResponse.Info = "Email is not the same as username.";
                return domainResponse;
            }
            Email = email;
            UserName = email;
            domainResponse.IsSuccess = true;
            return domainResponse;
        }

        public DomainResponse SetAlias(string alias)
        {
            DomainResponse domainResponse = new DomainResponse();
            if (alias.IsNullOrEmpty())
            {
                domainResponse.IsSuccess = false;
                domainResponse.Info = "Username is not the same as username.";
                return domainResponse;
            }
            Alias = alias;
            domainResponse.IsSuccess = true;
            return domainResponse;
        }
    }
}
