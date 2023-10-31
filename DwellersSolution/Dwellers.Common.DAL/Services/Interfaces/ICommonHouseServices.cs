using Dwellers.Common.DAL.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Services.Interfaces
{
    public interface ICommonHouseServices
    {
        Task<HouseEntity> GetHouseForOtherServicesById(Guid Id);
    }
}
