using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Application.Interfaces.Bulletins
{
    public interface IBulletinCommandRepository
    {
        Task<int> SaveChangesAsync();

        Task<bool> AddBulletin(Bulletin bulletin); 
        Task<bool> DeleteBulletin(Bulletin bulletin);
        Task<SaveChangesEventArgs> SaveChanges(SaveChangesEventArgs args);

    }
}
