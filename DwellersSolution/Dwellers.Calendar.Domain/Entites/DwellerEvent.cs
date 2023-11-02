using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Calendar.Domain.Entites.ValueObjects;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Calendar.Domain.Entites
{
    public sealed class DwellerEvent : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; private set; }
        public Visibility EventScope { get; private set; }


        public DwellerEvent(AddEventCommand cmd)
        {
            Id = Guid.NewGuid();
            Title = cmd.Title;
            Description = cmd.Desc;
            IsCreated = DateTime.Now;
            IsArchived = false;
        }

        public async Task<DomainResponse> SetScopeFromUI(string scope)
        {
            DomainResponse response = new();

            int parsedScope = int.Parse(scope);
            if (parsedScope < 0 || parsedScope > 2)
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = "Could not set scope.";
                return response;
            }
            var scopeResponse = await SetScopeFromDB(parsedScope);
            return scopeResponse;
        }

        public async Task<DomainResponse> SetScopeFromDB(int scope)
        {
            DomainResponse response = new();
            try
            {
                EventScope = Visibility.FromDbValue(scope);
                response.IsSuccess = true;
                return response;
            }
            catch (ArgumentException ex)
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = ex.Message;
                return response;
            }
        }
    }
}
