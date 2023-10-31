using Dwellers.Common.DAL.Models.Notes;

namespace Dwellers.Common.DAL.Models.Household
{
    public sealed class DwellerUserEntity
    {
        public string Id { get; set; }
        public ICollection<HouseUserEntity> HouseUsers { get; set; }
        public ICollection<NoteEntity> Notes { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DwellerUserEntity() { }

    }
}
