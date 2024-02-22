using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellers
{
    public class DwellerCommandRepository : IDwellerCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<DwellerCommandRepository> _logger;

        public DwellerCommandRepository(DwellerDbContext context, ILogger<DwellerCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddDweller(Dweller dweller)
        {
            try
            {
                await _context.Dwellers.AddAsync(dweller);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDweller(Dweller dweller)
        {
            throw new NotImplementedException();
        }
    }
}
