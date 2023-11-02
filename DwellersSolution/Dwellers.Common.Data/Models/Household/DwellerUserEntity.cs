using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Data.Models.Household
{
    public sealed class DwellerUserEntity
    {
        public string Id { get; set; }
        public ICollection<HouseUserEntity> HouseUsers { get; set; }
        public ICollection<NoteEntity> Notes { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerUserEntity() { }

    }
}
