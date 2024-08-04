using ApiRestaurante.Core.Application.ViewModels.Users;
using ApiRestaurante.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using ApiRestaurante.Core.Application.Dtos.Account;

namespace ApiRestaurante.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;  

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
