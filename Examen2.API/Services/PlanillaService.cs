using Examen2.API.Database;
using Examen2.API.Database.Entities;
using Examen2.API.Dtos.Common;
using Examen2.API.Dtos.Planillas;
using Examen2.API.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Examen2.API.DTOS.Planillas;

namespace Examen2.API.Services;

public class PlanillaService : IPlanillaService
{
    private readonly SistemaPagosDbContext _context;
    private readonly IMapper _mapper;

    public PlanillaService(SistemaPagosDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseDto<List<PlanillaDto>>> GetAllAsync()
    {
        var planillas = await _context.Planillas.ToListAsync();
        var planillasDto = _mapper.Map<List<PlanillaDto>>(planillas);

        return new ResponseDto<List<PlanillaDto>>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Planillas obtenidas exitosamente",
            Status = true,
            Data = planillasDto
        };
    }

    public async Task<ResponseDto<PlanillaDto>> GetByIdAsync(int id)
    {
        var planilla = await _context.Planillas.FindAsync(id);

        if (planilla == null)
        {
            return new ResponseDto<PlanillaDto>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Planilla no encontrada",
                Status = false,
                Data = null
            };
        }

        var planillaDto = _mapper.Map<PlanillaDto>(planilla);

        return new ResponseDto<PlanillaDto>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Planilla obtenida exitosamente",
            Status = true,
            Data = planillaDto
        };
    }

    public async Task<ResponseDto<PlanillaDto>> CreateAsync(PlanillaCreateDto planillaDto)
    {
        var nuevaPlanilla = _mapper.Map<PlanillaEntity>(planillaDto);

        _context.Planillas.Add(nuevaPlanilla);
        await _context.SaveChangesAsync();

        var result = _mapper.Map<PlanillaDto>(nuevaPlanilla);

        return new ResponseDto<PlanillaDto>
        {
            StatusCode = HttpStatusCode.Created,
            Message = "Planilla creada exitosamente",
            Status = true,
            Data = result
        };
    }

    public async Task<ResponseDto<PlanillaDto>> UpdateAsync(int id, PlanillaUpdateDto planillaDto)
    {
        var planilla = await _context.Planillas.FindAsync(id);

        if (planilla == null)
        {
            return new ResponseDto<PlanillaDto>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Planilla no encontrada",
                Status = false,
                Data = null
            };
        }

        _mapper.Map(planillaDto, planilla);
        await _context.SaveChangesAsync();

        var result = _mapper.Map<PlanillaDto>(planilla);

        return new ResponseDto<PlanillaDto>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Planilla actualizada exitosamente",
            Status = true,
            Data = result
        };
    }

    public async Task<ResponseDto<bool>> DeleteAsync(int id)
    {
        var planilla = await _context.Planillas.FindAsync(id);

        if (planilla == null)
        {
            return new ResponseDto<bool>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Planilla no encontrada",
                Status = false,
                Data = false
            };
        }

        _context.Planillas.Remove(planilla);
        await _context.SaveChangesAsync();

        return new ResponseDto<bool>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Planilla eliminada exitosamente",
            Status = true,
            Data = true
        };
    }

    public async Task<ResponseDto<List<PlanillaDto>>> GetByPeriodoAsync(string periodo)
    {
        var planillas = await _context.Planillas
            .Where(p => p.Periodo == periodo)
            .ToListAsync();

        var planillasDto = _mapper.Map<List<PlanillaDto>>(planillas);

        return new ResponseDto<List<PlanillaDto>>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Planillas obtenidas por periodo exitosamente",
            Status = true,
            Data = planillasDto
        };
    }

    public async Task<ResponseDto<bool>> UpdateEstadoAsync(int id, bool nuevoEstado)
    {
        var planilla = await _context.Planillas.FindAsync(id);

        if (planilla == null)
        {
            return new ResponseDto<bool>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Planilla no encontrada",
                Status = false,
                Data = false
            };
        }

        planilla.Activo = nuevoEstado;
        await _context.SaveChangesAsync();

        return new ResponseDto<bool>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Estado de planilla actualizado exitosamente",
            Status = true,
            Data = true
        };
    }
}
