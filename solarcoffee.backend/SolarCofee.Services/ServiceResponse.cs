﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCofee.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public T Data { get; set; }
    }
}
