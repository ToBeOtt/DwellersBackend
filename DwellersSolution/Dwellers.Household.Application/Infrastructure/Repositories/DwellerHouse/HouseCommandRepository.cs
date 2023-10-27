﻿using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Infrastructure.Repositories.DwellerHouse
{
    public class HouseCommandRepository : IHouseCommandRepository
    {
        private readonly HouseholdDbContext _context;

        public HouseCommandRepository(HouseholdDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHouse(House House)
        {
            await _context.Houses.AddAsync(House);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddHouseUser(HouseUser houseUser)
        {
            await _context.HouseUsers.AddAsync(houseUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
