using Dwellers.Common.DAL.Models.DwellerEvents;

namespace Dwellers.Calendar.Application.Interfaces
{
    public interface IDwellerEventsCommandRepository
    {
        Task<bool> AddEvent(DwellerEventEntity dwellerEvent);
    }
}
