using Dwellers.Household.Application.Features.Household.DwellerServices.Commands;
using Dwellers.Household.Domain.Exceptions;
using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Domain.Entities.DwellerServices
{
    public sealed class DwellerService
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ServiceScope { get; private set; }
        public bool ServiceStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }
        

        public ICollection<ProvidedService> ProvidedServices { get; set; }

        public DwellerService() { }

        public DwellerService(AddDwellerServiceCommand cmd)
        {
            Id = Guid.NewGuid();
            Name = cmd.Name;
            Description = cmd.Description;
            ServiceStatus = true;
            DateAdded = DateTime.UtcNow;

            if (Enum.TryParse(cmd.ServiceScope, out VisibilityScope scope))
            {
                ServiceScope = scope;
            }
            else throw new EntityCreationFailed("Failed to convert value to enum");
        }
    }
}

