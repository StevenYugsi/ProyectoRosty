using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models.Entidades;
namespace ProyectoRosty.Models
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext() {
        }
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {

        }
        public DbSet<Bodega> bodegas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> empleados { get; set; }
        public DbSet<GestionDeGaseosas> GestionDeGaseosas { get; set; }
        public DbSet<RegistroDeVentas> RegistroDeVentas { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
