using Dwellers.Common.DAL.Models.DwellerItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Offerings.Application.Interfaces.DwellerItems
{
    public interface IDwellerItemQueryRepository
    {
        Task<DwellerItemEntity> GetDwellerItem(Guid ItemId);
        Task<ICollection<DwellerItemEntity>> GetAllDwellerItems(Guid houseId);
    }
}
