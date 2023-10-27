using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using FluentValidation;

namespace Dwellers.Household.Application.Features.Authentication.Commands.RegisterHouse
{
    public class RegisterHouseCommandValidator : AbstractValidator<RegisterHouseCommand>
    {
        public RegisterHouseCommandValidator()
        {
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Password).NotEmpty();
        }
    }
}
