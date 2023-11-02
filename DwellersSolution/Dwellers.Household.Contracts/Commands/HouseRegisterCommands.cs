namespace Dwellers.Household.Contracts.Commands
{
    public record RegisterHouseCommand(
       string Name,
       string Description,
       string Email);

    public record RegisterMemberToHouseCommand(
       Guid Invitation,
       string Email);
}
