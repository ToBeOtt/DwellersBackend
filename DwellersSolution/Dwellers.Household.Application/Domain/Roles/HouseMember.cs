using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Domain.Roles
{
    public class HouseMember : IdentityRole
    {
        public HouseMember() : base("HouseMember")
        {
        }
    }
}
