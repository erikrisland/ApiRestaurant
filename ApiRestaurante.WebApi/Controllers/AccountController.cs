using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            private readonly IAccountService _accountService;

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

            [HttpPost("authenticate")]
            public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
            {
                return Ok(await _accountService.AuthenticateAsync(request));
            }

            [HttpPost("register/mesero")]
            public async Task<IActionResult> RegisterAsync(RegisterRequest request)
            {
                var origin = Request.Headers["origin"];
                return Ok(await _accountService.RegisterBasicUserAsync(request, origin));
            }

            [HttpPost("register/admin")]
            public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
            {
                var origin = Request.Headers["origin"];
                return Ok(await _accountService.RegisterAdminUserAsync(request, origin));
            }

    }
    }
