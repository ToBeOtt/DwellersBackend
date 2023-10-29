using Microsoft.IdentityModel.Tokens;

namespace Dwellers.Authentication.Domain
{
    public sealed class DwellerUser
    {
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Alias { get; private set; }
        public byte[]? ProfilePhoto { get; private set; }

        public DwellerUser() { }

        public DomainResponse CreateUser(string email, string username, string alias)
        {
            DomainResponse domainResponse = new DomainResponse();
            var emailResponse = SetEmail(email);
            if (!emailResponse.IsSuccess) return (emailResponse);

            var usernameResponse = SetUsername(username);
            if (!usernameResponse.IsSuccess) return (usernameResponse);

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
            domainResponse.IsSuccess = true;
            return domainResponse;
        }

        public DomainResponse SetUsername(string username)
        {
            DomainResponse domainResponse = new DomainResponse();
            if (this.Email != null && this.Email != username)
            {
                domainResponse.IsSuccess = false;
                domainResponse.Info = "Username is not the same as username.";
                return domainResponse;
            }
            UserName = username;
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
