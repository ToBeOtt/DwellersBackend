using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Infrastructure.Repositories.DwellerCore.Repositories.Dwellers
{
    public class DwellerQueryRepository : IDwellerQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllDwellers()
        {
            throw new NotImplementedException();
        }

        public async Task<Dweller> GetDwellerById(string id)
        {
            return _context.Dwellers.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<Dweller> GetDwellerByEmail(string email)
        {
            throw new NotImplementedException();
            //return _context.Dwellers.Where(u => u.Email == email).SingleOrDefault();
        }
    }
}
