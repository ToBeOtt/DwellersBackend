using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Data.Context;
using Dwellers.Common.Persistance.BulletinModule.Interfaces;
using Dwellers.Common.Persistance.Common;
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


        public async Task AddAsync(Bulletin bulletin)
        {
            _context.Bulletins.AddAsync(bulletin);
            await Save();
        }

        public async Task<Bulletin> GetByIdAsync(BulletinId id)
        {
            return await _context.Bulletins.FindAsync(id);
        }

        Task IBulletinRepository.DeleteAsync(Bulletin bulletin)
        {
            throw new NotImplementedException();
        }

        Task IBulletinRepository.UpdateAsync(Bulletin bulletin)
        {
            throw new NotImplementedException();
        }
    }
}
