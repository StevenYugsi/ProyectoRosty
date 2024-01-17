using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioGestiones
    {
        Task<GestionDeGaseosas> GetGestionDeGaseosas(string Nombre, int CantidadDisponible, decimal PrecioUnitario 
            ,string FechaIngreso, string Proveedor, string Descripcion);
        Task<GestionDeGaseosas> SaveGestionDeGaseosas(GestionDeGaseosas Nombre);
        Task<GestionDeGaseosas> GetGestionDeGaseosas(string nombreProducto);
    }
}
