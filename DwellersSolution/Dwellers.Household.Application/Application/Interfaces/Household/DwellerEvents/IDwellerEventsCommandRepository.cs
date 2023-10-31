using Dwellers.Common.DAL.Models.DwellerEvents;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerEvents
{
    public interface IDwellerEventsCommandRepository
    {
        Task<bool> AddEvent(DwellerEventEntity dwellerEvent);
    }
}
