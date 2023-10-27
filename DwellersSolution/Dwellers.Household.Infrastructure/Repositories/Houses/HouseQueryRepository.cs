using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Application.Interfaces;
using Dwellers.Household.Domain.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System.Reflection.Metadata.Ecma335;
using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Infrastructure.Repositories.Houses
{
    public class HouseQueryRepository : IHouseQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public HouseQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }

        public async Task<House> GetHouseByInvite(Guid householdCode)
        {
            return await _context.Houses.Where(h => h.HouseholdCode == householdCode).SingleOrDefaultAsync();
        }

        public async Task<HouseUser> GetHouseByUserID(string userId)
        {
           return await _context.HouseUsers.Where(x => x.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<House> GetHouseById(Guid houseId)
        {
            return await _context.Houses.Where(x => x.HouseId == houseId).SingleOrDefaultAsync();
        }
    }
}