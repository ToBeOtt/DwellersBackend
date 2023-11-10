using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain.DomainModels;
using SharedKernel.Domain.DomainResponse;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class BulletinTag : ValueObject
    {
        private string _tag;
        private BulletinId _bulletinId;

        private BulletinTag() { }
        internal BulletinTag CreateNewTag(string newTag, BulletinId bulletinId)
        {
             return new BulletinTag(newTag, bulletinId);
        }

        private BulletinTag(string newTag, BulletinId bulletinId)
        {
            _tag = newTag;
            _bulletinId = bulletinId;
        }

        public string GetTag()
        {
            return _tag;
        }

        public static class BulletinTagFactory
        {
            public static List<BulletinTag> CreateNewCollectionOfTags
                (List<string> newTags, BulletinId bulletinId)
            {
                List<BulletinTag> newListOfTags = new();
                foreach (var tag in newTags)
                {
                    tag.ToUpper();
                    newListOfTags.Add(new BulletinTag(tag, bulletinId));
                }
                CheckRule(new NoDuplicateTagsMayExist(newListOfTags, null));
                return newListOfTags;
            }
        }

        internal DomainResponse<bool> AddTagToCollection
            (List<BulletinTag> currentTags, string newTag, BulletinId id)
        {
            DomainResponse<bool> response = new();
            //CheckRule(new NoDuplicateTagsMayExist(currentTags, newTag));

            var outcome = DwellerValidation(new DomainIsBroken(currentTags, newTag));
            if(!outcome.IsSuccess)
                return response.ErrorResponse(outcome, outcome.DomainErrorMessage);

            CreateNewTag(newTag, id);
            return response;
        }
    }
}
