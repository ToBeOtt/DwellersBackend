using FluentValidation;

namespace Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterHouse
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
