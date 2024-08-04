using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
