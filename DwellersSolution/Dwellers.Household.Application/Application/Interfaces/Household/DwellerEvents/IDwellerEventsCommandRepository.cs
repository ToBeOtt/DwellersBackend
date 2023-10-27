using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerEvents;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerEvents
{
    public interface IDwellerEventsCommandRepository
    {
        Task<bool> AddEvent(DwellerEvent dwellerEvent);
    }
}
