using FluentValidation;

namespace Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterMemberToHouse
{
    public class RegisterMemberToHouseCommandValidator : AbstractValidator<RegisterMemberToHouseCommand>
    {
        //public RegisterMemberToHouseCommandValidator()
        //{
        //    RuleFor(x => x.Email).EmailAddress();
        //    RuleFor(x => x.Password).NotEmpty();
        //}
    }
}