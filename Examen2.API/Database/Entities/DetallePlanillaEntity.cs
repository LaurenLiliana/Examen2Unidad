using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.API.Database.Entities
{
    public class DetallePlanillaEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(PlantillaId))]
        [Column("plantilla_id")]
        public int PlantillaId { get; set; }

        [ForeignKey(nameof(EmpleadoId))]
        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        [Column("salario_base")]
        public decimal SalarioBase { get; set; }

        [Column("horas_extra")]
        public decimal HorasExtra { get; set; }

        [Column("montos_horas_extra")]
        public decimal MontoHorasExtra { get; set; }

        [Column("bonificaciones")]
        public decimal Bonificaciones { get; set; }

        [Column("deducciones")]
        public decimal Deducciones { get; set; }

        [Column("salario_neto")]
        public decimal SalarioNeto { get; set; }

        [Column("comentarios")]
        public string Comentarios { get; set; }

        public PlanillaEntity Planilla { get; set; }
        public EmpleadoEntity Empleado { get; set; }
    }
}


  