using Microsoft.Extensions.Logging;

namespace SharedKernel.Application.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T? Data { get; set; }
        public string? ErrorMessage{ get; set; }

        public virtual async Task<ServiceResponse<T>> ErrorResponse
            (ServiceResponse<T> response, string message, ILogger logger, string? logMessage = null) 
        {
            response.IsSuccess = false;
            response.ErrorMessage = message;
            if (logMessage != null)
            {
                logger.LogInformation(logMessage);
            }
            else logger.LogInformation(message);
            return response;
        }

        public virtual async Task<ServiceResponse<T>> SuccessResponse
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
