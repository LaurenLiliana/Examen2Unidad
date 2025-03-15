using Examen2.API.Dtos.Empleados;
using Examen2.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen2.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpleadoDto>>> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

   
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);

            if (empleado == null)
            {
                return NotFound(new { message = $"Empleado con ID {id} no encontrado" });
            }

            return Ok(empleado);
        }


        [HttpGet("activos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpleadoDto>>> GetEmpleadosActivos()
        {
            var empleadosActivos = await _empleadoService.GetEmpleadosActivosAsync();
            return Ok(empleadosActivos);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoActionResponseDto>> CreateEmpleado(EmpleadoCreateDto empleadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _empleadoService.CreateEmpleadoAsync(empleadoDto);

            if (!resultado.Success)
            {
                return BadRequest(resultado);
            }

         
            return CreatedAtAction(
                nameof(GetEmpleado),
                new { id = resultado.EmpleadoId },
                resultado
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoActionResponseDto>> UpdateEmpleado(int id, EmpleadoEditDto empleadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _empleadoService.EditEmpleadoAsync(id, empleadoDto);

            if (!resultado.Success)
            {
                if (resultado.Message.Contains("no encontrado"))
                {
                    return NotFound(resultado);
                }
                return BadRequest(resultado);
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoActionResponseDto>> DeleteEmpleadoAsync(int id)
        {
            var resultado = await _empleadoService.DeleteAsync(id);

            if (!resultado.Success)
            {
                return NotFound(resultado);
            }
        }
    }
}
