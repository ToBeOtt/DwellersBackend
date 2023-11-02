namespace Dwellers.Authentication.Application.Services.Responses
{
    public class RegisterServiceResponse<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
