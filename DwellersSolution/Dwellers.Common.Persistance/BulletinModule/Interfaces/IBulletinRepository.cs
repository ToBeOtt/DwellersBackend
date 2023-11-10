using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Common.Persistance.BulletinModule.Interfaces
{
    public interface IBulletinRepository
    { 
        Task AddAsync(Bulletin bulletin);
        Task UpdateAsync(Bulletin bulletin);
        Task DeleteAsync(Bulletin bulletin);

        Task<Bulletin> GetByIdAsync(BulletinId id);
    }
}
