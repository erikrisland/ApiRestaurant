using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.ViewModels.Users;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<RegisterResponse> RegisterAdminAsync(SaveUserViewModel vm, string origin);
        Task SignOutAsync();
    }
}