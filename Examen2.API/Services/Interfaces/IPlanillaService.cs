using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Planillas;
using Examen2.API.DTOS.Planillas;

namespace Examen2.API.Services.Interfaces
{
    public interface IPlanillaService
    {
        Task<ResponseDto<List<PlanillaDto>>> GetAllPlanillasAsync();
        Task<ResponseDto<PlanillaDto>> GetPlanillaByIdAsync(int id);
        Task<ResponseDto<PlanillaActionResponseDto>> CreatePlanillaAsync(PlanillaCreateDto planillaDto);
        Task<ResponseDto<PlanillaActionResponseDto>> UpdatePlanillaAsync(int id, PlanillaEditDto planillaDto);
        Task<ResponseDto<PlanillaActionResponseDto>> DeletePlanillaAsync(int id);
        Task<ResponseDto<List<PlanillaDto>>> GetPlanillasByPeriodoAsync(string periodo);
        Task<ResponseDto<PlanillaActionResponseDto>> UpdateEstadoPlanillaAsync(int id, string nuevoEstado);
    }
}
