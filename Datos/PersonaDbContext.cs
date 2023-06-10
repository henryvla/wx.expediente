using Microsoft.EntityFrameworkCore;
using ws.expediente.Modelos;

namespace ws.expediente.Datos
{

    public class PersonaDbContext : DbContext
    {
        public PersonaDbContext(DbContextOptions<PersonaDbContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
