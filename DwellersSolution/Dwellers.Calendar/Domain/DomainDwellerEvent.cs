using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Common.DAL.Models.Common.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Dwellers.Calendar.Domain
{
    public sealed class DomainDwellerEvent 
    { 
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; private set; }
        public VisibilityScope EventScope { get; private set; }
     
        public bool Archived { get; private set; }
        public DateTime EventCreated { get; private set; }
        public DateTime? EventModified { get; private set; }

        public DomainDwellerEvent(AddEventCommand cmd)
        {
            Id = Guid.NewGuid();
            Title = cmd.Title;
            Description = cmd.Desc;
            Archived = false;
            EventCreated = DateTime.Now;
        }

        public async Task<DomainResponse> SetScope(string scope)
        {
            DomainResponse response = new();
            if (Enum.TryParse(scope, out VisibilityScope eventScope))
            {
                EventScope = eventScope;
                response.IsSuccess = true;
                return response;
            }
            response.IsSuccess = false;
            response.DomainErrorResponse = "Could not set scope.";
            return response;
        }
    }
}
