using Examen2.API.Dtos.Planillas;
using Examen2.API.DTOS.Planillas;
using Examen2.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examen2.API.Controllers
{
    [Route("api/Planillas")]
    [ApiController]
    public class PlanillasController : ControllerBase
    {
        private readonly IPlanillaService _planillaService;

        public PlanillasController(IPlanillaService planillaService)
        {
            _planillaService = planillaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanillas()
        {
            var response = await _planillaService.GetAllPlanillasAsync();
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanilla(int id)
        {
            var response = await _planillaService.GetPlanillaByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanilla([FromBody] PlanillaCreateDto planillaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _planillaService.CreatePlanillaAsync(planillaDto);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanilla(int id, [FromBody] PlanillaEditDto planillaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _planillaService.EditPlanillaAsync(id, planillaDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanilla(int id)
        {
            var response = await _planillaService.DeletePlanillaAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }



    }
}