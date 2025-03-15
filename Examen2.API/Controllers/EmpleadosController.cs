using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Empleados;
using Examen2.API.Services;
using Examen2.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Examen2.API.Controllers
{
    [ApiController]
    [Route("api/Empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var response = await _empleadoService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("activos")]
 
        public async Task<IActionResult> GetActivos()
        {
            var response = await _empleadoService.GetActivosAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _empleadoService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateDto empleado)
        {
            var response = await _empleadoService.CreateAsync(empleado);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoEditDto empleado)
        {
            var response = await _empleadoService.EditAsync(id, empleado);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _empleadoService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}