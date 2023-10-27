using FluentValidation;

namespace Dwellers.Household.Application.Authentication.Queries.GetUserDetails
{
    public class LoginQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public LoginQueryValidator()
        {
        }

    }
}
