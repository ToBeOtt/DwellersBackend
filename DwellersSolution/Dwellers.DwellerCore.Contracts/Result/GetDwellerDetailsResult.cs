namespace Dwellers.DwellerCore.Contracts.Result
{
    public record GetDwellerDetailsResult
   (
       string DwellerId,
       Guid DwellingId
   );

}
