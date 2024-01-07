using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.DwellerCore.Domain.DomainServices
{
    internal class GetAllDwellingNames
    {
        private readonly IDwellingRepository _dwellingRepository;

        public GetAllDwellingNames(IDwellingRepository dwellingRepository)
        {
            _dwellingRepository = dwellingRepository;
        }

        internal async Task<List<string>> FetchAllDwellingNames()
        {
            return await _dwellingRepository.GetAllDwellingNames();
        }
    }
}
