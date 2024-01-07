using Dwellers.Bulletins.Domain.Bulletins.DomainEvents;
using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Status
    {
        Pending,
        Initialized,
        Done
    }

    public class BulletinStatus : BaseEntity
    {
        private Status _status;

        private BulletinStatus() { }
        private BulletinStatus(string statusValue)
        {
            var status = ConvertPriorityFromUIValue(statusValue);
            _status = status;
        }

        internal static class BulletinStatusFactory
        {
            internal static BulletinStatus CreateNewStatus(string strStatusValue)
            {
                return new BulletinStatus(strStatusValue);
            }
        }

        internal void ModifyBulletinStatus(Status status, BulletinId bulletinId)
        {
            DwellerValidation(new StatusHasNotChanged(_status, status));

            _status = status;
            if(status == Status.Done)
            {
                var @event = new BulletinStatusChangedToDoneDomainEvent(bulletinId);
                this.AddDomainEvent(@event);
            }
        }

        internal void ConvertStatusFromDbValue(int dbValue)
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

        internal static Status ConvertPriorityFromUIValue(string uiValue)
        {
            if (int.TryParse(uiValue, out int parsedvalue) && 
                Enum.IsDefined(typeof(Status), parsedvalue))
            {
                return (Status)parsedvalue;
            }
            throw new ArgumentException("Invalid value for priority");
        }
    }
}