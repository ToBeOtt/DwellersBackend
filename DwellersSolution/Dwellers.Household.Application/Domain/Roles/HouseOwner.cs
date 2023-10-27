using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Domain.Roles
{
    public class HouseOwner : IdentityRole
    {
        public HouseOwner() : base("HouseOwner")
        {
        }
    }
}

