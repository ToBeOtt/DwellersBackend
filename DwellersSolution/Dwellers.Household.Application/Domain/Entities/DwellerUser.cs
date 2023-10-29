using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.Entities.Notes;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerUser : IdentityUser
    {
        public ICollection<HouseUser> HouseUsers { get; set; }
        public ICollection<Note> Notes { get; set; }
        public string Alias { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DwellerUser() { }

    }
}
