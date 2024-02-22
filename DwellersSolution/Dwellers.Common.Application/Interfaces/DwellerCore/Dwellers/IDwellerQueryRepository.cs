using Dwellers.DwellerCore.Domain.Entities.Dwellers;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers
{
    public interface IDwellerQueryRepository
    {
        Task<List<string>> GetAllDwellers();
        Task<Dweller> GetDwellerById(string id);
        Task<Dweller> GetDwellerByEmail(string email);
    }
}
