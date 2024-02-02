using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioRegistros
    {
        Task<RegistroDeVentas> GetRegistroDeVentas(string VentasDiarias, string DetalleVenta, string FechaDeVenta, decimal TotalVenta);
        Task<RegistroDeVentas> SaveRegistroDeVentas(RegistroDeVentas VentasDiarias);
        Task<RegistroDeVentas> GetRegistroDeVentas(string nombreVenta);
    }
}
