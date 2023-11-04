using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletin.Domain.Bulletins.DomainEvents
{
    public class BulletinStatusChangedToDoneDomainEvent : DomainEventBase
    {
        public Guid BulletinId { get; }


        public BulletinStatusChangedToDoneDomainEvent(Guid bulletinId)
        {
            BulletinId = bulletinId;
        }
    }
}
