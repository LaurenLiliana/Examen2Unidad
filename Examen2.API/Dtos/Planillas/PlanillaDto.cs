using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Examen2.API.Database.Entities;
using Examen2.API.Dtos.DetallesPlantillas;

namespace Examen2.API.Dtos.Planillas
{
    public class PlanillaDto
    {
        public int Id { get; set; }
        public string Periodo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
        public ICollection<DetallePlanillaDto> DetallesPlanilla { get; set; }
    } 
}
