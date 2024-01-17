using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public class ServicioBodegas : IServicioBodegas
    {
        private readonly LibreriaContext _context;

        public ServicioBodegas(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Bodega> GetBodega(string Nombre, int Cantidad, decimal PrecioUnitario, string FechaIngreso)
        {
           Bodega Bodega = await _context.bodegas.Where(u => u.Nombre == Nombre && u.Cantidad == Cantidad && u.PrecioUnitario == PrecioUnitario 
           && u.FechaIngreso == FechaIngreso).FirstOrDefaultAsync();
            return Bodega;
        }

        public async Task<Bodega> GetBodega(string nombreProducto)
        {
            return await _context.bodegas.FirstOrDefaultAsync(u => u.Nombre == nombreProducto);
        }

        public async Task<Bodega> SaveBodega(Bodega Nombre)
        {
            _context.bodegas.Add(Nombre);
            await _context.SaveChangesAsync();
            return Nombre;
        }
    }
}
