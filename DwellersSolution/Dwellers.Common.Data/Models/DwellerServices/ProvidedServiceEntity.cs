namespace Dwellers.Common.Data.Models.DwellerServices
{
    public class ProvidedServiceEntity
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }

        public Guid ServiceId { get; set; }

        public bool IsProvider { get; set; }
        public string? Note { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }
        public bool? ServiceReturned { get; set; }

        public ProvidedServiceEntity() { }

        public ProvidedServiceEntity(Guid dwellingId, Guid serviceId, bool isProvider)
        {
            DwellingId = dwellingId;
            ServiceId = serviceId;
            IsProvider = isProvider;
        }
    }
}
