using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public interface IBulletinRepository
    {
        Task<Bulletin> GetById(BulletinId id);
        Task<bool> AddBulletin(Bulletin bulletin);
        Task<bool> DeleteBulletin(Bulletin bulletin);
    }
}
