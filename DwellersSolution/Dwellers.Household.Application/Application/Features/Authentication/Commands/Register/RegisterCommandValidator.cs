using Dwellers.Household.Application.Features.Authentication.Commands.Register;
using FluentValidation;

namespace Dwellers.Household.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Alias).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }           
    }
}
