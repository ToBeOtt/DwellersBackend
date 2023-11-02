using Dwellers.Common.Data.Models.Common.ValueObjects;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Contracts.Commands;

namespace Dwellers.Offerings.Domain.Entities.DwellerServices
{
    public sealed class DomainDwellerService
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ServiceScope { get; private set; }
        public bool ServiceStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }


        public ICollection<ProvidedServiceEntity> ProvidedServices { get; set; }

        public DomainDwellerService() { }

        public DomainDwellerService(AddDwellerServiceCommand cmd)
        {
            Id = Guid.NewGuid();
            Name = cmd.Name;
            Description = cmd.Description;
            DateAdded = DateTime.UtcNow;
        }

        public DomainResponse SetServiceScope(string scope)
        {
            DomainResponse response = new();
            if (Enum.TryParse(scope, out VisibilityScope serviceScope))
            {
                ServiceScope = serviceScope;
                response.IsSuccess = true;
                return response;
            }
            response.IsSuccess = false;
            response.DomainErrorResponse = "Scope could not be parsed to enum.";
            return response;
        }
    }
}

