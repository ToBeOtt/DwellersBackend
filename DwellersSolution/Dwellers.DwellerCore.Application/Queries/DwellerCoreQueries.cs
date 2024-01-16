using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellerCore.Interfaces;

namespace Dwellers.DwellerCore.Queries
{
    //internal class DwellerCoreQueries : IDwellerCoreQueries
    //{
    //    private readonly DwellerDbContext _context;

    //    public DwellerCoreQueries(DwellerDbContext context)
    //    {
    //        _context = context;
    //    }

    //    Task<DwellingInhabitant> IDwellerCoreQueries.GetDwellerInhabitantByDwellerId(string Id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    Task<Dwelling> IDwellerCoreQueries.GetDwellingByInvite(Guid invite)
    //    {
    //        throw new NotImplementedException();
    //    }

        //public async Task<DwellingInhabitant> GetDwellerInhabitantById(string id)
        //{
        //    _context.DwellingInhabitants.Where(di => di.DwellerId == id).SingleOrDefaultAsync();
        //}

        //private async Task<Dwelling> GetDwellingByInvite(Guid invitationCode)
        //{
        //    return await _context.Dwellings
        //                        .Where(d => d.InvitationCode == invitationCode)
        //                        .SingleOrDefaultAsync();
        //}
    //}
}
