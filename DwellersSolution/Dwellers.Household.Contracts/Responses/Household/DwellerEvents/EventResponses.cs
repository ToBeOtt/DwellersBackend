using Dwellers.Household.Domain.Entities.DwellerEvents;

namespace Dwellers.Household.Contracts.Responses.Household.DwellerEvents
{
    public record AddEventResponse(
        bool Success);

    public record GetEventResponse(
       DwellerEvent Event,
       string EventScope);

    public record GetAllEventsResponse(
        ICollection<DwellerEvent> Events);

    public record GetUpcomingEventsResponse(
        ICollection<DwellerEvent> Events);
}
