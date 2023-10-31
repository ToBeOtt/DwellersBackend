using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerServices;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerService
{
    internal class DwellerServiceCommandRepository : IDwellerServiceCommandRepository
    {
        private readonly ILogger<DwellerServiceCommandRepository> _logger;
        private readonly DwellerDbContext _context;

        public DwellerServiceCommandRepository(
            ILogger<DwellerServiceCommandRepository> logger,
            DwellerDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        private async Task<int> SaveActions()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
        }
        public async Task<bool> AddDwellerService(DwellerServiceEntity service)
        {
            await _context.DwellerServices.AddAsync(service);
            int result = await SaveActions();
            return result > 0;
        }

        public Task<bool> RegisterProvidedService(ProvidedServiceEntity service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDwellerService(DwellerServiceEntity service)
        {
            throw new NotImplementedException();
        }
    }
}
