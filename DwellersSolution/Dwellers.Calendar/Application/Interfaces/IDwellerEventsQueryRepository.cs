using Dwellers.Common.DAL.Models.DwellerEvents;

namespace Dwellers.Calendar.Application.Interfaces
{
    public interface IDwellerEventsQueryRepository
    {
        Task<DwellerEventEntity> GetEvent(Guid eventId);
        Task<ICollection<DwellerEventEntity>> GetAllEvents(Guid houseId);
        Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid houseId);
    }
}
