using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Empleados;

namespace Examen2.API.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDto>> GetAllEmpleadosAsync();
        Task<EmpleadoDto> GetEmpleadoByIdAsync(int id);
        Task<List<EmpleadoDto>> GetEmpleadosActivosAsync();
        Task<EmpleadoActionResponseDto> CreateEmpleadoAsync(EmpleadoCreateDto empleadoDto);
        Task<EmpleadoActionResponseDto> EditEmpleadoAsync(int id, EmpleadoEditDto empleadoDto);
        Task<ResponseDto<EmpleadoActionResponseDto>> DeleteAsync(int id);
    }

}
