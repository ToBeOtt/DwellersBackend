using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Authentication.Commands.RegisterHouse
{
    public record RegisterHouseResult(
        DwellerUser User,
        House House
    );




}
