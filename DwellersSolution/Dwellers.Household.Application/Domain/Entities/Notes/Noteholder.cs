using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Common.DAL.Models.DwellerChat.ValueObjects;
using Dwellers.Household.Application.Features.Household.Notes.Commands.AddNoteholder;

namespace Dwellers.Household.Domain.Entities.Notes
{
    public sealed class Noteholder
    {
        public Guid NoteholderId { get; private set; }
        public string Name { get; private set; }
        public Category? Category { get; private set; }
        public VisibilityScope? NoteholderScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }


        public Noteholder() { }
        public Noteholder(AddNoteholderCommand cmd)
        {
            NoteholderId = Guid.NewGuid();
            Archived = false;
            DateCreated = DateTime.Now;
            Name = cmd.Name;

            if (Enum.TryParse(cmd.NoteholderScope, out VisibilityScope scope))
            {
                NoteholderScope = scope;
            }
            else NoteholderScope = VisibilityScope.Household;

            if (Enum.TryParse(cmd.Category, out Category category))
            {
                Category = category;
            }
            else Category = null;
        }

    }
}
