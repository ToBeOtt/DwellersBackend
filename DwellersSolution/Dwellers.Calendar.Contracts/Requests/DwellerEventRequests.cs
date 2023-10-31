namespace Dwellers.Calendar.Contracts.Requests
{
    public record AddEventRequest(
        string Title,
        string Desc,
        DateTime EventDate,
        string EventScope);

    public record GetAllEventsRequest(
    );

    public record GetUpcomingEventsRequest(
     );

}
