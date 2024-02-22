using Dwellers.DwellersEvents.Domain.Entites;

namespace Dwellers.Common.Application.Interfaces.DwellerEvents
{
    public interface IDwellerEventsCommandRepository
    {
        Task<bool> AddEvent(DwellerEvent dwellerEvent);
    }
}
