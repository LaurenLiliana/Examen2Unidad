using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.API.Database.Entities
{
    [Table("empleados")]
    public class EmpleadoEntity
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Nombre { get; set; }

        [Column("apellido")]
        [Required]
        public string Apellido { get; set; }

        [Column("documento")]
        [Required]
        public string Documento { get; set; }

        [Column("fecha_contratacion")]
        public DateTime FechaContratacion { get; set; }

        [Column("departamento")]
        public string Departamento { get; set; }

        [Column("puesto_trabajo")]
        public string PuestoTrabajo { get; set; }

        [Column("salario_base")]
        public decimal SalarioBase { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<DetallePlanillaEntity> DetallesPlanilla { get; set; }
    }
}
