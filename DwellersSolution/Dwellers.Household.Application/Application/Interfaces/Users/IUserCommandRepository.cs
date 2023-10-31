using Dwellers.Common.DAL.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Interfaces.Users
{
    public interface IUserCommandRepository
    {
        Task<bool> AddUser(DwellerUserEntity User);
        Task<bool> UpdateUser(DwellerUserEntity User);
    }
}
