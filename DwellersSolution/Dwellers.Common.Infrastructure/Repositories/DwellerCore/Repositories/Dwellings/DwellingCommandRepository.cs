using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellings
{
    public class DwellingCommandRepository : IDwellingCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<DwellingCommandRepository> _logger;

        public DwellingCommandRepository(DwellerDbContext context, 
            ILogger<DwellingCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task AddDwelling(Dwelling Dwelling)
        {
            throw new NotImplementedException();
        }
        public async Task AddDwellerInhabitant(DwellingInhabitant DwellerInhabitant)
        {
            await _context.DwellingInhabitants.AddAsync(DwellerInhabitant);
        }

        public async Task DeleteDwelling(Dwelling Dwelling)
        {
            throw new NotImplementedException();
            //await _context.Dwellings.Remove(Dwelling);
        }
    }
}
