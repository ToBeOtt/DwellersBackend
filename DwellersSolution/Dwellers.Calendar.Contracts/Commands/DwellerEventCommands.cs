namespace Dwellers.Calendar.Contracts.Commands
{
    public record AddEventCommand(
        string Title,
        string Desc,
        string EventScope,
        DateTime EventDate,
        string DwellerId,
        Guid DwellingId
        );
}
