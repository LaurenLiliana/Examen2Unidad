using Examen2.API.Database;
using Examen2.API.Database.Entities;
using Examen2.API.Dtos.Empleados;
using Examen2.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Examen2.API.Dtos.Common;

namespace Examen2.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly SistemaPagosDbContext _context;

        public EmpleadoService(SistemaPagosDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadoDto>> GetAllEmpleadosAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            return empleados.Select(MapToDto).ToList();
        }

        public async Task<EmpleadoDto> GetEmpleadoByIdAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            return empleado != null ? MapToDto(empleado) : null;
        }

        public async Task<List<EmpleadoDto>> GetEmpleadosActivosAsync()
        {
            var empleadosActivos = await _context.Empleados
                .Where(e => e.Activo)
                .ToListAsync();

            return empleadosActivos.Select(MapToDto).ToList();
        }

        public async Task<EmpleadoActionResponseDto> CreateEmpleadoAsync(EmpleadoCreateDto empleadoDto)
        {
            if (await _context.Empleados.AnyAsync(e => e.Documento == empleadoDto.Documento))
            {
                return EmpleadoActionResponseDto.Error("Ya existe un empleado con este documento");
            }

            var nuevoEmpleado = new EmpleadoEntity
            {
                Nombre = empleadoDto.Nombre,
                Apellido = empleadoDto.Apellido,
                Documento = empleadoDto.Documento,
                FechaContratacion = empleadoDto.FechaContratacion,
                Departamento = empleadoDto.Departamento,
                PuestoTrabajo = empleadoDto.PuestoTrabajo,
                SalarioBase = empleadoDto.SalarioBase,
                Activo = empleadoDto.Activo
            };

            await _context.Empleados.AddAsync(nuevoEmpleado);
            await _context.SaveChangesAsync();

            return EmpleadoActionResponseDto.CreacionExitosa(nuevoEmpleado.Id);
        }

        public async Task<EmpleadoActionResponseDto> EditEmpleadoAsync(int id, EmpleadoEditDto empleadoDto)
        
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return EmpleadoActionResponseDto.Error("Empleado no encontrado");
            }

            empleado.Nombre = empleadoDto.Nombre;
            empleado.Apellido = empleadoDto.Apellido;
            empleado.Departamento = empleadoDto.Departamento;
            empleado.PuestoTrabajo = empleadoDto.PuestoTrabajo;
            empleado.SalarioBase = empleadoDto.SalarioBase;
            empleado.Activo = empleadoDto.Activo;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();

            return EmpleadoActionResponseDto.ActualizacionExitosa(id);
        }

        public async Task<EmpleadoActionResponseDto> DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return EmpleadoActionResponseDto.Error("Empleado no encontrado");
            }

            empleado.Activo = false;
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();

            return EmpleadoActionResponseDto.EliminacionExitosa(id);
        }


        private EmpleadoDto MapToDto(EmpleadoEntity empleado)
        {
            return new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Documento = empleado.Documento,
                FechaContratacion = empleado.FechaContratacion,
                Departamento = empleado.Departamento,
                PuestoTrabajo = empleado.PuestoTrabajo,
                SalarioBase = empleado.SalarioBase,
            };
        }
    }
}
