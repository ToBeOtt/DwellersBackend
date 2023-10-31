namespace Dwellers.Calendar.Contracts.Queries
{
    public record GetEventQuery(
    Guid EventId);
    public record GetUpcomingEventsQuery(
    Guid HouseId);

}
