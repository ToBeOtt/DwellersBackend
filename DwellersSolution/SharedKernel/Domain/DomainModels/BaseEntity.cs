namespace SharedKernel.Domain.DomainModels
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool IsArchived { get; protected set; }
        public DateTime IsCreated { get; protected set; }
        public DateTime? IsModified { get; protected set; }
    }
}
