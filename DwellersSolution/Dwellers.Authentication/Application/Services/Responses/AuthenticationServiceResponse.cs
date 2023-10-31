using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Authentication.Application.Services.Responses
{
      public class AuthenticationServiceResponse<T>
    {
        public T? Data { get; set; }
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
