using AutoMapper;
using Examen2.API.Database.Entities;
using Examen2.API.Dtos.Empleados;
using Examen2.API.Dtos.Planillas;
using Examen2.API.DTOS.Planillas;

namespace Examen2.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmpleadoEntity, EmpleadoDto>();
            CreateMap<EmpleadoCreateDto, EmpleadoEntity>();
            CreateMap<EmpleadoEditDto, EmpleadoEntity>();
            CreateMap<EmpleadoEntity, Dtos.Empleados.PlanillaActionResponseDto>();

            CreateMap<PlanillaEntity, PlanillaDto>();
            CreateMap<PlanillaCreateDto, PlanillaEntity>();
            CreateMap<PlanillaEditDto, PlanillaEntity>();
            CreateMap<PlanillaEntity, Dtos.Empleados.PlanillaActionResponseDto>();
        }
        
    }
}
