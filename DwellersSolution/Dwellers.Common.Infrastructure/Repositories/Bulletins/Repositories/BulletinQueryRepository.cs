using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Interfaces.Bulletins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Infrastructure.Repositories.Bulletins.Repositories
{
    public class BulletinQueryRepository : IBulletinQueryRepository
    {
        Task<Bulletin> IBulletinQueryRepository.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
