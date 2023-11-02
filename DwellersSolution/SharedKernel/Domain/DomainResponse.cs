using Azure;

namespace SharedKernel.Domain
{
    public class DomainResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? DomainErrorResponse { get; set; }

        public virtual async Task<DomainResponse<bool>> LogAndReturnResponse(string message)
        {
            DomainResponse<bool> response = new();
            response.IsSuccess = false;
            response.DomainErrorResponse = message;
            return response;
        }
    }
}
