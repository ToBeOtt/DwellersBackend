namespace Dwellers.Common.Application.Contracts.Queries.DwellerEvents
{
    public record GetEventQuery(
    Guid EventId);

    public record GetAllEventsQuery(
   Guid HouseId);

    public record GetUpcomingEventsQuery(
    Guid HouseId);

}