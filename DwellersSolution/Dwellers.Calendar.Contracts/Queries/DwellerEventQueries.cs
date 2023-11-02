namespace Dwellers.Calendar.Contracts.Queries
{
    public record GetEventQuery(
    Guid EventId);

    public record GetAllEventsQuery(
   Guid HouseId);

    public record GetUpcomingEventsQuery(
    Guid HouseId);

}