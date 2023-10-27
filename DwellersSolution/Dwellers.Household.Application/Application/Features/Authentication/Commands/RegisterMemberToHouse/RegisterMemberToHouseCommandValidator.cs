using Dwellers.Household.Application.Authentication.Commands.RegisterMemberToHouse;
using FluentValidation;

namespace Dwellers.Household.Application.Features.Authentication.Commands.RegisterMemberToHouse
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