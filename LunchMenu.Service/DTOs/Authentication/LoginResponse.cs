using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Service.DTOs.Authentication
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public int? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
