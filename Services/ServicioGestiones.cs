using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public class ServicioGestiones : IServicioGestiones
    {
        private readonly LibreriaContext _context;

        public ServicioGestiones(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<GestionDeGaseosas> GetGestionDeGaseosas
            (string Nombre, int CantidadDisponible, decimal PrecioUnitario, string FechaIngreso, string Proveedor, string Descripcion)
        {
            GestionDeGaseosas gestionDeGaseosas = await _context.GestionDeGaseosas.Where
                (u => u.Nombre == Nombre && u.CantidadDisponible == CantidadDisponible && u.PrecioUnitario == PrecioUnitario
           && u.FechaIngreso == FechaIngreso && u.Proveedor == Proveedor && u.Descripcion == Descripcion).FirstOrDefaultAsync();
            return gestionDeGaseosas;
        }

        public async Task<GestionDeGaseosas> GetGestionDeGaseosas(string nombreProducto)
        {
            return await _context.GestionDeGaseosas.FirstOrDefaultAsync(u => u.Nombre == nombreProducto);
        }

        public async  Task<GestionDeGaseosas> SaveGestionDeGaseosas(GestionDeGaseosas Nombre)
        {
            _context.GestionDeGaseosas.Add(Nombre);
            await _context.SaveChangesAsync();
            return Nombre;
        }
    }
}
