using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings
{
    public interface IDwellingCommandRepository
    {
        Task Save();
        Task AddDwelling(Dwelling Dwelling);
        Task AddDwellerInhabitant(DwellingInhabitant DwellerInhabitant);
        Task DeleteDwelling(Dwelling Dwelling);
    }
}
