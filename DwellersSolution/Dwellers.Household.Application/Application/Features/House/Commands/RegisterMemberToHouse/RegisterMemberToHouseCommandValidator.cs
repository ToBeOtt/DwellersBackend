using Dwellers.Household.Contracts.Commands;
using FluentValidation;

namespace Dwellers.Household.Application.Features.House.Commands.RegisterMemberToHouse
{
    public class RegisterMemberToHouseCommandValidator : AbstractValidator<RegisterMemberToHouseCommand>
    {
        public RegisterMemberToHouseCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}