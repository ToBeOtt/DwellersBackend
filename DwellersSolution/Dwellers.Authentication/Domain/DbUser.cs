using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Authentication.Domain
{
    public sealed class DbUser : IdentityUser
    {
        public string Alias { get; private set; }

        public DbUser() { }

        public async Task<DomainResponse<bool>> CreateUser(string email, string alias)
        {
            DomainResponse<bool> domainResponse = new();

            var emailResponse = await SetEmail(email);
            if (!emailResponse.IsSuccess) return (emailResponse);

            var aliasResponse = await SetAlias(alias);
            if (!aliasResponse.IsSuccess) return (aliasResponse);

            return domainResponse.SuccessResponse(domainResponse);
        }

        public async Task<DomainResponse<bool>> SetEmail(string email)
        {
            DomainResponse<bool> domainResponse = new();
            if (this.UserName != null && this.UserName != email)
                return domainResponse.ErrorResponse(domainResponse, "Email is not the same as username.");

            Email = email;
            UserName = email;

            return domainResponse.SuccessResponse(domainResponse);
        }

        public async Task<DomainResponse<bool>> SetAlias(string alias)
        {
            DomainResponse<bool> domainResponse = new();
            if (alias.IsNullOrEmpty())
                return domainResponse.ErrorResponse(domainResponse, "Username is not the same as username.");

            Alias = alias;
            return domainResponse.SuccessResponse(domainResponse);
        }
    }
}
