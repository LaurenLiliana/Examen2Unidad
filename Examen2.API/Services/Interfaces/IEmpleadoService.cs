using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Empleados;

namespace Examen2.API.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(EmpleadoCreateDto empleadoDto);
        Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(int id);
        Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(int id, EmpleadoEditDto empleadoDto);
        Task<ResponseDto<List<EmpleadoDto>>> GetActivosAsync();
        Task<ResponseDto<List<EmpleadoDto>>> GetAllAsync();
        Task<ResponseDto<EmpleadoDto>> GetByIdAsync(int id);
    }
}
