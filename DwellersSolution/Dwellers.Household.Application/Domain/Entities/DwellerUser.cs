using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.Entities.Notes;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerUser : IdentityUser
    {
        public ICollection<HouseUser> HouseUsers { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<DwellerMessage> DwellerMessages { get; private set; }
        public string Alias { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DwellerUser() { }


        // ROLE ASSIGNMENT
        private DwellerUser AssignRole(DwellerUser user)
        {
            throw new NotImplementedException();
        }

        // CRUD-service methods...
        private void UpdateRole(DwellerUser user)
        {
            throw new NotImplementedException();
        }
        private void DeleteUser(DwellerUser user)
        {
            throw new NotImplementedException();
        }
    }
}
