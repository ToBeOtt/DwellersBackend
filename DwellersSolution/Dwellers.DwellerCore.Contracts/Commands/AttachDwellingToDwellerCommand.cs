namespace Dwellers.DwellerCore.Contracts.Commands
{
    public record AttachDwellingToDwellerCommand(
       string Name,
       string Description,
       string Email);

}