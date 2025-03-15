using System;

namespace Examen2.API.Dtos.Empleados
{
    public class PlanillaActionResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaContratacion { get; set; } = DateTime.Now;
    }
}