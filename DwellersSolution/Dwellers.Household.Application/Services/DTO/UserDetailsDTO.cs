using Dwellers.Common.Data.Models.Household;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Household.Services.DTO
{
    public record UserDetailsDTO
   (
       DwellerUserEntity? User,
       HouseEntity? House
   );

}
