using Dwellers.Bulletin.Domain.Bulletins.DomainEvents;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph.Models.Security;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletin.Domain.Bulletins
{
    public class Bulletin : SharedKernel.Domain.DomainModels.Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        private string _name;
        private string _description;

        private List<BulletinTag> _tags;
        private BulletinStatus _status;

        private List<Guid> _houseIds;

        private bool _isArchived;

        public static Bulletin CreateNewBulletin(
            string name, 
            string description, 
            List<BulletinTag> tags,
            int bulletinStatus,
            List<Guid> houseIds
            )
        {
            return new Bulletin(name, description, tags, bulletinStatus, houseIds);
        }
        private Bulletin(
            string name,
            string description,
            List<BulletinTag> tags,
            int bulletinStatus,
            List<Guid> houseIds
            )
        {
            Id = Guid.NewGuid();
            _name = name;
            _description = description;
            _tags = tags;
            _status.ConvertStatusFromDbValue(bulletinStatus);
            _houseIds = houseIds;
        }




        public void StatusUpdateToDone(BulletinStatusChangedToDoneDomainEvent @event)
        {
            if (@event.Id == this.Id)
            {
                _isArchived = true;
            }
        }
    }
}
