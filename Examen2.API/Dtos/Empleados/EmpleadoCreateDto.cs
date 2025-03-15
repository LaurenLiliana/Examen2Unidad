using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.API.Dtos.Empleados
{
    public class EmpleadoCreateDto
    {
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 100 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El documento es obligatorio")]
        [StringLength(20, MinimumLength = 13, ErrorMessage = "El documento debe tener 13 caracteres")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "La fecha de contratación es obligatoria")]
        public DateTime FechaContratacion { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        [StringLength(100)]
        public string PuestoTrabajo { get; set; }

        [Required(ErrorMessage = "El salario base es obligatorio")]
        [Range(0, 100000, ErrorMessage = "El salario base debe estar entre 0 y 100,000")]
        public decimal SalarioBase { get; set; }
        public bool Activo { get; set; } = true;
       
    }
}
