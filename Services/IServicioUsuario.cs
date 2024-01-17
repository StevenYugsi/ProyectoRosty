using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioUsuario
    {
        Task<Usuarios> GetUsuario(string correo, string contraseña);
        Task<Usuarios> SaveUsuario(Usuarios nombre);
        Task<Usuarios> GetUsuario(string nombreUsuario);
    }
}
