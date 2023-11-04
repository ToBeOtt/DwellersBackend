using Dwellers.Bulletin.Domain.Bulletins.DomainEvents;
using Dwellers.Bulletin.Domain.Bulletins.Rules;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletin.Domain.Bulletins
{
    public enum Status
    {
        Pending,
        Initialized,
        Done
    }

    public class BulletinStatus : Entity
    {
        private Status _status;
        private Guid _bulletinId;

        public static BulletinStatus CreateNewTag(Status status, Guid bulletinId)
        {
            return new BulletinStatus(status, bulletinId);
        }
        public BulletinStatus()
        {
            
        }
        private BulletinStatus(Status status, Guid bulletinId)
        {
            _status = status;
            _bulletinId = bulletinId;
        }

        public void ModifyBulletinStatus(Status status)
        {
            CheckRule(new StatusHasNotChanged(_status, status));

            _status = status;
            if(status == Status.Done)
            {
                var @event = new BulletinStatusChangedToDoneDomainEvent(_bulletinId);
                this.AddDomainEvent(@event);
            }
        }

        public void ConvertStatusFromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Status), dbValue))
            {
                _status = (Status)dbValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }
    }
}