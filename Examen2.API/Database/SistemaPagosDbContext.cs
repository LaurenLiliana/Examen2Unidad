using Examen2.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen2.API.Database
{
    public class SistemaPagosDbContext : DbContext
    {
        public SistemaPagosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmpleadoEntity> Empleados { get; set; } 
        public DbSet<PlanillaEntity> Planillas { get; set; }
        public DbSet<DetallePlanillaEntity> DetallePlantillas { get; set; }
    }
}
