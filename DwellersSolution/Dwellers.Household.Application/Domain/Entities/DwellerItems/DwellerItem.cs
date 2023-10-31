using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Household.Application.Features.Household.DwellerItems.Commands;
using Dwellers.Household.Domain.Exceptions;

namespace Dwellers.Household.Domain.Entities.DwellerItems
{
    public sealed class DwellerItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; set; }
        public bool ItemStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }


        public DwellerItem() { }

        public DwellerItem(AddDwellerItemCommand cmd)
        {
            Id = Guid.NewGuid();
            Name = cmd.Name;
            Description = cmd.Desc;
            ItemStatus = true;

            if (Enum.TryParse(cmd.ItemScope, out VisibilityScope scope))
            {
                ItemScope = scope;
            }
            else throw new EntityCreationFailed("Failed to convert value to enum");

            DateAdded = DateTime.UtcNow;
        }
    }
}
