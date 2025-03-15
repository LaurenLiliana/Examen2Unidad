using Examen2.API.Dtos.DetallesPlanillas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen2.API.DTOS.Planillas
{
    public class PlanillaCreateDto
    {
        [Required(ErrorMessage = "El periodo es obligatorio")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        public DateTime FechaPago { get; set; }

        public string Estado { get; set; }

        public ICollection<DetallePlanillaCreateDto> DetallesPlanilla { get; set; }
    }
}
