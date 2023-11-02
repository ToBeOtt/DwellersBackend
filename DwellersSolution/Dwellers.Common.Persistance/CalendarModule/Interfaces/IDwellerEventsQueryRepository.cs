using Dwellers.Common.Data.Models.DwellerEvents;

namespace Dwellers.Common.Persistance.CalendarModule.Interfaces
{
    public interface IDwellerEventsQueryRepository
    {
        Task<DwellerEventEntity> GetEvent(Guid eventId);
        Task<ICollection<DwellerEventEntity>> GetAllEvents(Guid houseId);
        Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid houseId);
    }
}
