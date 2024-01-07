using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.DwellerCore.Interfaces
{
    public interface IDwellerCoreQueries
    {
        Task<Dwelling> GetDwellingByInvite(Guid invite);
        Task<DwellingInhabitant> GetDwellerInhabitantByDwellerId(string Id);
        
    }
}
