﻿using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Infrastructure.Repositories.Bulletins.Repositories
{
    public class BulletinQueryRepository(DwellerDbContext context,
        ILogger<BulletinQueryRepository> logger) : IBulletinQueryRepository
    {
        private readonly DwellerDbContext _context = context;
        private readonly ILogger<BulletinQueryRepository> _logger = logger;

        public async Task<Bulletin> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bulletin>> GetDashboardBulletinsAsync(Guid id)
        {
            return await _context.Bulletins
                .Include(d => d.Dwellings)
                .Where(d => d.IsArchived != true)
                .OrderByDescending(n => n.IsCreated)
                .ThenByDescending(n => n.IsModified)
                .Where(n => n.IsCreated >= DateTime.UtcNow.AddDays(-10))
                .Take(10)
                .ToListAsync();             
        }
    }
}
