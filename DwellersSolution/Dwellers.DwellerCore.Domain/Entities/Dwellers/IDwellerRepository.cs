using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellers
{
    public interface IDwellerRepository
    {
        Task<Dweller> GetDwellerById(string id);
        Task<Dweller> GetDwellerByEmail(string email);
        Task<List<string>> GetAllDwellers();

        Task<bool> AddDweller(Dweller Dweller);
        Task<bool> UpdateDweller(Dweller Dweller);
        Task<bool> DeleteDweller(Dweller Dweller);

        Task<bool> AddDwellerInhabitant(DwellingInhabitant DwellerInhabitant);  
    }
}
