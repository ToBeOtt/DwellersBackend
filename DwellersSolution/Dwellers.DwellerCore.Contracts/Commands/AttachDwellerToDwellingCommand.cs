namespace Dwellers.DwellerCore.Contracts.Commands
{
    public record AttachDwellerToDwellingCommand(
     Guid Invitation,
     string Email);
}