using Dwellers.DwellersEvents.Domain.Entites;

namespace Dwellers.Common.Application.Interfaces.DwellerEvents
{
    public interface IDwellerEventsQueryRepository
    {
        Task<DwellerEvent> GetEvent(Guid eventId);
        Task<ICollection<DwellerEvent>> GetAllEvents(Guid houseId);
        Task<ICollection<DwellerEvent>> GetUpcomingEvents(Guid houseId);
    }
}
