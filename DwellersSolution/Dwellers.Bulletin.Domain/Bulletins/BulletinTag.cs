using Dwellers.Bulletin.Domain.Bulletins.Rules;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletin.Domain.Bulletins
{
    public class BulletinTag : ValueObject
    {
        private BulletinTag _tag;
       
        public static BulletinTag CreateNewTag(BulletinTag newTag)
        {
            
            return new BulletinTag(newTag);
        }

        private BulletinTag(BulletinTag newTag)
        {
            _tag = newTag;
        }

        public void AddTagToCollection(List<BulletinTag> currentTags, BulletinTag newTag)
        {
             CheckRule(new NoDuplicateTagsMayExist(currentTags, newTag));
            _tag = newTag;
        }
    }
}
