using Dwellers.Bulletins.Domain.Bulletins.DomainEvents;
using Dwellers.Bulletins.Domain.Bulletins.Rules;
using Microsoft.Graph.Models;
using SharedKernel.Domain.DomainModels;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinScope;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinTag;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class Bulletin : BaseEntity, IAggregateRoot
    {
        public readonly record struct BulletinId(Guid Value);
        public BulletinId Id { get; private set; }

        private string _title;
        private string _text;

        private List<BulletinTag> _tags;
        private BulletinStatus _status;
        private BulletinPriority _priority;
        private BulletinScope _scope;

        private List<Guid> _houseIds;
        private string _userId;

        private bool _isArchived;

        public Bulletin() { }

        private Bulletin(
            string userId,
            string title,
            string text,
            List<string> tags,
            BulletinPriority bulletinPriority,
            BulletinStatus bulletinStatus,
            List<Guid>? houseList,
            string visibility
            )
        {
            Id = new BulletinId(Guid.NewGuid());
            _userId = userId;
            _title = title;
            _text = text;
            _priority = bulletinPriority;
            _status = bulletinStatus;
            _tags = BulletinTagFactory.CreateNewCollectionOfTags(tags, Id);
            _scope = BulletinScopeFactory.SetBulletinScope(Id, houseList, visibility);
        }

        public static class BulletinPostFactory
        {
           public static Bulletin CreateNewBulletin(
                string userId,
                string title,
                string text,
                List<string> tags,
                BulletinPriority bulletinPriority,
                BulletinStatus bulletinStatus,
                List<Guid>? houseList,
                string visibility)
            {
                return new Bulletin(
                    userId,
                    title,
                    text,
                    tags,
                    bulletinPriority,
                    bulletinStatus,
                    houseList,
                    visibility);
            }
        }

        public void StatusUpdateToDone(BulletinStatusChangedToDoneDomainEvent @event)
        {
            _isArchived = true;
        }

        public void AddTags(List<BulletinTag> tags)
        {
            foreach(var tag in tags) 
            {
                CheckRule(new InputNotNullOrEmpty<BulletinTag>(tag));
                _tags.Add(tag);
            }
        }
    }
}
