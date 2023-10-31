using Dwellers.Common.DAL.Models.DwellerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Offerings.Application.Interfaces.DwellerServices
{
    public interface IDwellerServiceQueryRepository
    {
        Task<DwellerServiceEntity> GetDwellerService(Guid ServiceId);
        Task<ICollection<DwellerServiceEntity>> GetAllDwellerServices(Guid houseId);
    }
}
