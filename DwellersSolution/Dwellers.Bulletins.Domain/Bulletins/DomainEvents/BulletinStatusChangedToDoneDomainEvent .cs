using SharedKernel.Domain;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Bulletins.DomainEvents
{
    public class BulletinStatusChangedToDoneDomainEvent : DomainEventBase
    {
        public BulletinId BulletinId { get; }


        public BulletinStatusChangedToDoneDomainEvent(BulletinId bulletinId)
        {
            BulletinId = bulletinId;
        }
    }
}
