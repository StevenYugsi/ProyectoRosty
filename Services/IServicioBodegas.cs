using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioBodegas
    {
        Task<Bodega> GetBodega(string Nombre, int Cantidad, decimal PrecioUnitario , string FechaIngreso);
        Task<Bodega> SaveBodega(Bodega Nombre);
        Task<Bodega> GetBodega(string nombreProducto);
    }
}
