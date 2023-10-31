using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Household.Application.Features.Household.DwellerEvents.Commands;
using Dwellers.Household.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Dwellers.Household.Domain.Entities.DwellerEvents
{
    public sealed class DwellerEvent 
    { 
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        [Required]
        public DateTime EventDate { get; private set; }
        [Required]
        public VisibilityScope EventScope { get; private set; }
     
        public bool Archived { get; private set; }
        public DateTime EventCreated { get; private set; }
        public DateTime? EventModified { get; private set; }

        public Entities.DomainDwellerUser User { get; set; }
        public DwellerHouse.DwellerHouse House { get; set; }



        public DwellerEvent() { }

        public DwellerEvent(AddEventCommand cmd)
        {
            AssembleEvent(cmd);
        }

        private void AssembleEvent(AddEventCommand cmd)
        {
            Id = Guid.NewGuid();
            Title = cmd.Title;
            Description = cmd.Desc;
            Archived = false;
            EventCreated = DateTime.Now;

            if (Enum.TryParse(cmd.EventScope, out VisibilityScope scope))
            {
                EventScope = scope;
            }
            else throw new EntityCreationFailed("Failed to convert value to enum");
        }
    }
}
