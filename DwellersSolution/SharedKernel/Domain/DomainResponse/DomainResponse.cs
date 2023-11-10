namespace SharedKernel.Domain.DomainResponse
{
    public class DomainResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T? DomainData { get; set; }
        public string? DomainErrorMessage { get; set; }

        public virtual DomainResponse<T> ErrorResponse
            (DomainResponse<T> response, string? message = null)
        {
            response.IsSuccess = false;
            if (message != null)
                response.DomainErrorMessage = message;
            return response;
        }

        public virtual DomainResponse<T> SuccessResponse
         (DomainResponse<T> response, T data = default)
        {
            response.IsSuccess = true;
            if (response.DomainData == null)
            {
                response.DomainData = data;
            }

            return response;
        }
    }
}
