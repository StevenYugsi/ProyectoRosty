using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioRoles
    {
        Task<Roles> GetRoles(string Rol, string Descripcion);
        Task<Roles> SaveRoles(Roles rol);
        Task<Roles> GetRoles(string Rol);
    }
}
