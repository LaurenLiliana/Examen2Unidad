using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.API.Database.Entities
{
    public class PlanillaEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("periodo")]
        [Required]
        public string Periodo { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        public ICollection<DetallePlanillaEntity> DetallesPlanilla { get; set; }
    }
}

