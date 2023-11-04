using Dwellers.Offerings.Domain.ValueObjects;
using SharedKernel.Domain.DomainModels;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Offerings.Domain.DwellerServices
{
    public sealed class DwellerService : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ServiceScope { get; private set; }
        public bool ServiceStatus { get; private set; }


        public DwellerService() 
        {
            Id = Guid.NewGuid();
            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }

        public DwellerService(string name, string desc)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }

        public async Task<DomainResponse<bool>> SetServiceScope(string scope)
        {
            DomainResponse<bool> response = new();
            if (Enum.TryParse(scope, out VisibilityScope serviceScope))
            {
                ServiceScope = serviceScope;
                return await response.SuccessResponse(response);
            }

            return await  response.ErrorResponse(response, "Scope could not be parsed to enum.");
        }
    }
}

