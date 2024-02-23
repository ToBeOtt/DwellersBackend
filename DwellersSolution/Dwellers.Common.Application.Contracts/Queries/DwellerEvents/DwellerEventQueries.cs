namespace Dwellers.Common.Application.Contracts.Queries.DwellerEvents
{
    public record GetEventQuery(
    Guid EventId);

    public record GetAllEventsQuery(
   Guid DwellingId);

    public record GetUpcomingEventsQuery(
    Guid DwellingId);

}