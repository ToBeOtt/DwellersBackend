namespace Dwellers.DwellerCore.Contracts.Queries
{
    public record GetDwellerDetailsQuery(
         string DwellerId,
         Guid DwellingId
        );
}
