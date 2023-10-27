﻿namespace SharedKernel.Exceptions.Common
{
    public class ValidationErrorMessage
    {
        public ValidationErrorMessage(int statusCode, string message, List<string> validationMessages)
        {
            StatusCode = statusCode;
            Message = message;
            ValidationMessages = validationMessages;
        }
        public int StatusCode { get; }
        public string Message { get; }
        public List<string> ValidationMessages { get; }
    }
}
