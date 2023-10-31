namespace Dwellers.Household.Application.Services.Responses
{
    public class HouseRegisterResponse
    {
        public string? Name { get; set; }
        public Guid? HouseId { get; set; }
        public bool IsSuccess { get; set; }

        public string? ErrorMessage { get; set; }
        public string? ValidationMessage { get; set; }
    }
}
