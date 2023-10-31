using Dwellers.Common.DAL.Models.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerEvents;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerEvents
{
    public interface IDwellerEventsQueryRepository
    {
        Task<DwellerEventEntity> GetEvent(Guid eventId);
        Task<ICollection<DwellerEventEntity>> GetAllEvents(Guid houseId);
        Task<ICollection<DwellerEventEntity>> GetUpcomingEvents(Guid houseId);
    }
}
