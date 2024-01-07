namespace Dwellers.DwellerCore.Contracts.Commands
{
    public record AddDwellerCommand(
       string DwellerId,
       string Alias,
       string Email);
}
