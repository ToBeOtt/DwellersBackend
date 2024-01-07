using Dwellers.Common.Data.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.DwellerCoreModule.Repositories.Dwellers
{
    public class DwellerRepository : BaseRepository, IDwellerRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<DwellerRepository> _logger;

        public DwellerRepository
            (DwellerDbContext context,
            ILogger<DwellerRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddDweller(Dweller Dweller)
        {
            try
            {
                var result = _context.Dwellers.AddAsync(Dweller);
                return await Save();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return false;
            }
        }

        public async Task<bool> AddDwellerInhabitant(DwellingInhabitant DwellerInhabitant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDweller(Dweller Dweller)
        {
            throw new NotImplementedException();
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

        public async Task<bool> UpdateDweller(Dweller Dweller)
        {
            var result = _context.Dwellers.Update(Dweller);
            await _context.SaveChangesAsync();
            return false;
        }
    }
}


//public async Task<DwellerUserEntity> GetUserByEmail(string email)
//{
//    return _context.Users.Where(u => u.Email == email).SingleOrDefault();
//}

//public async Task<bool> CheckLoginCredentials(string username, string password)
//{
//    return true;
//}

//public async Task<DwellerUserEntity> GetUserForOtherServicesById(string userId)
//{
//    return _context.Users.Where(u => u.Id == userId).SingleOrDefault();
//}