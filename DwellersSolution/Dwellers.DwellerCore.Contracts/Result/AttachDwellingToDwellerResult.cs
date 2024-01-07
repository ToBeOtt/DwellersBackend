namespace Dwellers.DwellerCore.Contracts.Result
{
    public record AttachDwellingToDwellerResult
    (
        string Name,
        Guid DwellingId
    );
}
