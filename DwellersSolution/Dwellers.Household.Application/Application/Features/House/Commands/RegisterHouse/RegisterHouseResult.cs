using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Household.Application.Features.House.Commands.RegisterHouse
{
    public record RegisterHouseResult(
        DwellerUserEntity User,
        HouseEntity House
    );
}
