using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public class ServicioRegistro : IServicioRegistros
    {
        private readonly LibreriaContext _context;

        public ServicioRegistro(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<RegistroDeVentas> GetRegistroDeVentas(string VentasDiarias, string DetalleVenta, string FechaDeVenta, decimal TotalVenta)
        {
            RegistroDeVentas registroDeVentas = await _context.RegistroDeVentas.Where
                  (u => u.VentasDiarias == VentasDiarias && u.DetalleVenta == DetalleVenta && u.FechaDeVenta == FechaDeVenta
             && u.TotalVenta == TotalVenta).FirstOrDefaultAsync();
            return registroDeVentas;
        }

        public async Task<RegistroDeVentas> GetRegistroDeVentas(string nombreVenta)
        {
            return await _context.RegistroDeVentas.FirstOrDefaultAsync(u => u.VentasDiarias == nombreVenta);
        }

        public async Task<RegistroDeVentas> SaveRegistroDeVentas(RegistroDeVentas VentasDiarias)
        {
            _context.RegistroDeVentas.Add(VentasDiarias);
            await _context.SaveChangesAsync();
            return VentasDiarias;
        }
    }
}
