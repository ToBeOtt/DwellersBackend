﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Calendar.Services
{
    public class EventServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
