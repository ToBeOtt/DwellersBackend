using Dwellers.DwellerCore.Domain.Entities.Dwellers;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers
{
    public interface IDwellerCommandRepository
    {
        Task<bool> AddDweller(Dweller dweller);
        Task<bool> DeleteDweller(Dweller dweller);
    }
}
