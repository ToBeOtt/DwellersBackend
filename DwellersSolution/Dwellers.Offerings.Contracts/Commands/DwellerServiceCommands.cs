namespace Dwellers.Offerings.Contracts.Commands
{
    public record AddDwellerServiceCommand(
     string Name,
     string Description,
     string ServiceScope,
     Guid DwellingId
     );
}
