using SharedKernel;
using SharedKernel.Application;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellings
{
    public interface IDwellingRepository : ITransaction
    {
        Task<Dwelling> GetDwellingById(Guid id);
        Task<Dwelling> GetDwellingByEmail(string email);
        Task<List<string>> GetAllDwellingNames();
        Task<bool> AddDwelling(Dwelling Dwelling);
        Task<bool> DeleteDwelling(Dwelling Dwelling);
    }
}
