namespace Dwellers.Offerings.Application.Services.ServiceResponses
{
    public class OfferingsServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool? DisplayToUser { get; set; }
    }
}
