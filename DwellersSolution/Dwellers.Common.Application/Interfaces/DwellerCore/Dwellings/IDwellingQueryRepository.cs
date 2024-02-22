using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings
{
    public interface IDwellingQueryRepository
    {
        Task<List<string>> GetAllDwellingNames();
        Task<Dwelling> GetDwellingById(Guid id);
        Task<Dwelling> GetDwellingByEmail(string email);

        Task<List<Dwelling>> GetAllDwellingsByListOfIds(List<Guid> listOfDwellings);
        
    }
}
