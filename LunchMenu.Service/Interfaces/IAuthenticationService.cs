using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Service.DTOs.Authentication;

namespace LunchMenu.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest loginRequest);

    }
}
