using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Ordenes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MesaController : BaseApiController
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin, Basic")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MesaViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mesas = await _mesaService.GetAllViewModel();

                if (mesas == null || mesas.Count == 0)
                {
                    return NoContent();
                }

                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin, Admin, Basic")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMesaViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mesas = await _mesaService.GetByIdSaveViewModel(id);

                if (mesas == null)
                {
                    return NoContent();
                }

                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMesaViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SaveMesaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _mesaService.Add(vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMesaViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveMesaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _mesaService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetTableOrden/{mesaId}")]
        [Authorize(Roles = "SuperAdmin, Basic")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrdenViewModel>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTableOrden(int mesaId)
        {
            try
            {
                var ordenes = await _mesaService.GetOrdenesByMesaId(mesaId);

                if (ordenes == null || ordenes.Count == 0)
                {
                    return NoContent();
                }

                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ChangeStatus/{mesaId}")]
        [Authorize(Roles = "SuperAdmin, Basic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus(int mesaId, [FromBody] string nuevoEstado)
        {
            try
            {
                var result = await _mesaService.ChangeStatus(mesaId, nuevoEstado);

                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}