using Dwellers.Household.Domain.Entities.DwellerEvents;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerEvents
{
    public interface IDwellerEventsQueryRepository
    {
        Task<DwellerEvent> GetEvent(Guid eventId);
        Task<ICollection<DwellerEvent>> GetAllEvents(Guid houseId);
        Task<ICollection<DwellerEvent>> GetUpcomingEvents(Guid houseId);
    }
}
