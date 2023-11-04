using MediatR.NotificationPublishers;
using Microsoft.Graph.Models.Security;
using SharedKernel.Domain.DomainModels;
using System.Linq;

namespace Dwellers.Bulletin.Domain.Bulletins.Rules
{
    public class NoDuplicateTagsMayExist : IBusinessRule
    {
        private readonly BulletinTag _newTag;
        private readonly List<BulletinTag> _tags;
      
        internal NoDuplicateTagsMayExist(List<BulletinTag> tags, BulletinTag newTag)
        {
            _tags = tags;
            _newTag = newTag;   
        }

        public bool IsBroken()
        {
            var strNewTag = _newTag.ToString().ToUpper();
            return _tags.Select(tag => tag.ToString().ToUpper()).Any(strTag => strTag == strNewTag);
        }
        
        public string Message => "There can not be two identical tags";
    }
}
