using Dwellers.Common.DAL.Models.DwellerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Offerings.Application.Interfaces.DwellerServices
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(DwellerServiceEntity service);
        Task<bool> RegisterProvidedService(ProvidedServiceEntity service);
        Task<bool> RemoveDwellerService(DwellerServiceEntity service);
    }
}
