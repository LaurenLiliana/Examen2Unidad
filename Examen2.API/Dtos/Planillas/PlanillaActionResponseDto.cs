namespace Examen2.API.Dtos.Planillas
{
    public class PlanillaActionResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int PlanillaId { get; set; }
        public string Periodo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
