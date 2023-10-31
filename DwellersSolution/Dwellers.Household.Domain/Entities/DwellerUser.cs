namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerUser
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DwellerUser() { }

    }
}
