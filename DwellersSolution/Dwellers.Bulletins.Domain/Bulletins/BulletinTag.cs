using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;
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
                DwellerValidation(new NoDuplicateTagsMayExist(newListOfTags, null));
                return newListOfTags;
            }
        }

        internal async Task<DwellerResponse<bool>> AddTagToCollection
            (List<BulletinTag> currentTags, string newTag, BulletinId id)
        {
            DwellerResponse<bool> response = new();
            DwellerValidation(new NoDuplicateTagsMayExist(currentTags, newTag));

            var outcome = DwellerValidation(new DomainIsBroken(currentTags, newTag));
            if(!outcome.IsSuccess)
                return await response.ErrorResponse(outcome.ErrorMessage);

            CreateNewTag(newTag, id);
            return await response.SuccessResponse();
        }
    }
}
