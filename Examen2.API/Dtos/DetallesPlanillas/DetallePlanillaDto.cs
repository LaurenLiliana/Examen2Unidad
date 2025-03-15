using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.API.Dtos.DetallesPlantillas
{
    public class DetallePlanillaDto
    {
        public int Id { get; set; }
        public int PlantillaId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal MontoHorasExtra { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal SalarioNeto { get; set; }
        public string Comentarios { get; set; }
    }
}
