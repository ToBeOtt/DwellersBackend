using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellersEvents.Domain.Entites.ValueObjects;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellersEvents.Domain.Entites
{
    public sealed class DwellerEvent : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; private set; }
        public Visibility? EventScope { get; private set; }
        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public Dwellers.DwellerCore.Domain.Entities.Dwellers.Dweller Dweller { get; set; }
        public Dwelling Dwelling { get; set; }

        public DwellerEvent() { }
        public DwellerEvent(string title, string desc, Dwelling dwelling, DwellerCore.Domain.Entities.Dwellers.Dweller dweller)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = desc;
            Dwelling = dwelling;
            Dweller = dweller;

            IsCreated = DateTime.Now;
            IsArchived = false;
        }

        public async Task<DwellerResponse<bool>> SetScopeFromUI(string scope)
        {
            DwellerResponse<bool> response = new();

            int parsedScope = int.Parse(scope);
            if (parsedScope < 0 || parsedScope > 2)
            {
                return await response.ErrorResponse("Could not set scope.");
            }
            var scopeResponse = await SetScopeFromDB(parsedScope);
            return scopeResponse;
        }

        public async Task<DwellerResponse<bool>> SetScopeFromDB(int scope)
        {
            DwellerResponse<bool> response = new();
            try
            {
                EventScope = Visibility.FromDbValue(scope);
                return await response.SuccessResponse();
            }
            catch (ArgumentException ex)
            {
                return await response.ErrorResponse(ex.Message);
            }
        }
    }

    public class Dweller
    {
    }
}
