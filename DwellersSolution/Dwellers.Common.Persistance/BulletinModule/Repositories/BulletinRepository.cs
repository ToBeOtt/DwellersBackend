using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Data.Context;
using Dwellers.Common.Persistance.Common;
using Microsoft.EntityFrameworkCore;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Common.Persistance.BulletinModule.Repositories
{
    public class BulletinRepository : BaseRepository, IBulletinRepository 
    {
        private readonly DwellerDbContext _context;

        public BulletinRepository(DwellerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddBulletin(Bulletin bulletin)
        {
            _context.Bulletins.AddAsync(bulletin);
            return await Save();
        }

        public async Task<Bulletin> GetById(BulletinId id)
        {
            return await _context.Bulletins.Where(b => b.Id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteBulletin(Bulletin bulletin)
        {
            _context.Bulletins.Update(bulletin);
            return await Save();
        }
    }
}
