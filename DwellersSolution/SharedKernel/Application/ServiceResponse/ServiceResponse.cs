using Microsoft.Extensions.Logging;

namespace SharedKernel.Application.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorResponse { get; set; }

        public virtual async Task<ServiceResponse<T>> ReturnError
            (ServiceResponse<T> response, string message, ILogger logger, string? logMessage = null) 
        {
            response.IsSuccess = false;
            response.ErrorResponse = message;
            if (logMessage != null)
            {
                logger.LogInformation(logMessage);
            }
            else logger.LogInformation(message);
            return response;
        }

        public virtual async Task<ServiceResponse<T>> ReturnSuccess
         (ServiceResponse<T> response, T data = default)
        {
            response.IsSuccess = true;
            if(response.Data == null)
            {
                response.Data = data;
            }
           
            return response;
        }
    }
}
