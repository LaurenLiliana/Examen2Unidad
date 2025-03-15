using Examen2.API.Constants;
using Examen2.API.Database.Entities;
using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Empleados;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Examen2.API.Services.Interfaces;
using Examen2.API.Database;

namespace Examen2.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly SistemaPagosDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadoService(SistemaPagosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<EmpleadoDto>>> GetAllAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            var empleadosDto = _mapper.Map<List<EmpleadoDto>>(empleados);

            return new ResponseDto<List<EmpleadoDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Empleados obtenidos exitosamente",
                Status = true,
                Data = empleadosDto
            };
        }

        public async Task<ResponseDto<List<EmpleadoDto>>> GetActivosAsync()
        {
            var empleadosActivos = await _context.Empleados
                .Where(e => e.Activo)
                .ToListAsync();

            var empleadosActivosDto = _mapper.Map<List<EmpleadoDto>>(empleadosActivos);

            return new ResponseDto<List<EmpleadoDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Empleados activos obtenidos exitosamente",
                Status = true,
                Data = empleadosActivosDto
            };
        }

        public async Task<ResponseDto<EmpleadoDto>> GetByIdAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Message = $"Empleado con ID {id} no encontrado",
                    Status = false,
                    Data = null
                };
            }

            var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);

            return new ResponseDto<EmpleadoDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Empleado obtenido exitosamente",
                Status = true,
                Data = empleadoDto
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(EmpleadoCreateDto empleadoDto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var empleadoExistente = await _context.Empleados
                        .FirstOrDefaultAsync(e => e.Documento == empleadoDto.Documento);

                    if (empleadoExistente != null)
                    {
                        return new ResponseDto<PlanillaActionResponseDto>
                        {
                            StatusCode = HttpStatusCode.CONFLICT,
                            Message = $"Ya existe un empleado con el mismo dni {empleadoDto.Documento}",
                            Status = false,
                            Data = null
                        };
                    }

                    var nuevoEmpleado = _mapper.Map<EmpleadoEntity>(empleadoDto);

                    _context.Empleados.Add(nuevoEmpleado);
                    await _context.SaveChangesAsync();

                    var responseData = new PlanillaActionResponseDto
                    {
                        Id = nuevoEmpleado.Id,
                        Nombre = nuevoEmpleado.Nombre,
                        Apellido = nuevoEmpleado.Apellido,
                        Documento = nuevoEmpleado.Documento,
                        Activo = nuevoEmpleado.Activo,
                        FechaContratacion = DateTime.Now
                    };

                    await transaction.CommitAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.CREATED,
                        Message = "Empleado creado exitosamente",
                        Status = true,
                        Data = responseData
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                        Message = $"Error al crear el empleado: {ex.Message}",
                        Status = false,
                        Data = null
                    };
                }
            }
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(int id, EmpleadoEditDto empleadoDto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var empleado = await _context.Empleados.FindAsync(id);

                    if (empleado == null)
                    {
                        return new ResponseDto<PlanillaActionResponseDto>
                        {
                            StatusCode = HttpStatusCode.NOT_FOUND,
                            Message = $"Empleado con ID {id} no encontrado",
                            Status = false,
                            Data = null
                        };
                    }

                    if (empleado.Documento != empleadoDto.Documento)
                    {
                        var empleadoExistente = await _context.Empleados
                            .FirstOrDefaultAsync(e => e.Documento == empleadoDto.Documento && e.Id != id);

                        if (empleadoExistente != null)
                        {
                            return new ResponseDto<PlanillaActionResponseDto>
                            {
                                StatusCode = HttpStatusCode.CONFLICT,
                                Message = $"Ya existe otro empleado con el mismo dni {empleadoDto.Documento}",
                                Status = false,
                                Data = null
                            };
                        }
                    }


                    _mapper.Map(empleadoDto, empleado);

                    await _context.SaveChangesAsync();

                    var responseData = new PlanillaActionResponseDto
                    {
                        Id = empleado.Id,
                        Nombre = empleado.Nombre,
                        Apellido = empleado.Apellido,
                        Documento = empleado.Documento,
                        Activo = empleado.Activo,
                        FechaContratacion = DateTime.Now
                    };

                    await transaction.CommitAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Empleado actualizado exitosamente",
                        Status = true,
                        Data = responseData
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                        Message = $"Error al actualizar el empleado: {ex.Message}",
                        Status = false,
                        Data = null
                    };
                }
            }
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var empleado = await _context.Empleados.FindAsync(id);

                    if (empleado == null)
                    {
                        return new ResponseDto<PlanillaActionResponseDto>
                        {
                            StatusCode = HttpStatusCode.NOT_FOUND,
                            Message = $"Empleado con ID {id} no encontrado",
                            Status = false,
                            Data = null
                        };
                    }

                    empleado.Activo = false;
                    await _context.SaveChangesAsync();
                    var responseData = new PlanillaActionResponseDto
                    {
                        Id = empleado.Id,
                        Nombre = empleado.Nombre,
                        Apellido = empleado.Apellido,
                        Documento = empleado.Documento,
                        Activo = empleado.Activo,
                        FechaContratacion = DateTime.Now
                    };

                    await transaction.CommitAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Empleado eliminado con exito",
                        Status = true,
                        Data = responseData
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    return new ResponseDto<PlanillaActionResponseDto>
                    {
                        StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                        Message = $"Error al eliminar el empleado: {ex.Message}",
                        Status = false,
                        Data = null
                    };
                }
            }
        }
    }
}