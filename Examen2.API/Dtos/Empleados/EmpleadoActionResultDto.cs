namespace Examen2.API.Dtos.Empleados
{
    public class EmpleadoActionResponseDto
    {
    public bool Success { get; set; }
    public string Message { get; set; }
    public int EmpleadoId { get; set; }

    public static EmpleadoActionResponseDto CreacionExitosa(int empleadoId) =>
        new EmpleadoActionResponseDto
        {
            Success = true,
            Message = "Empleado creado exitosamente",
            EmpleadoId = empleadoId
        };

        public static EmpleadoActionResponseDto ActualizacionExitosa(int empleadoId) =>
            new EmpleadoActionResponseDto
            {
                Success = true,
                Message = "Empleado actualizado exitosamente",
                EmpleadoId = empleadoId
            };

        public static EmpleadoActionResponseDto EliminacionExitosa(int empleadoId) =>
            new EmpleadoActionResponseDto
            {
                Success = true,
                Message = "Empleado eliminado exitosamente",
                EmpleadoId = empleadoId
            };

        public static EmpleadoActionResponseDto Error(string mensaje) =>
            new EmpleadoActionResponseDto
            {
                Success = false,
                Message = mensaje
            };
    }
}
