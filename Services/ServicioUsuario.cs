using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoRosty.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly LibreriaContext _context;

        public ServicioUsuario(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> GetUsuario(string correo,string contraseña)
        {
            Usuarios usuarios = await _context.usuarios.Where(u =>  u.Correo == correo && u.Contraseña == contraseña).FirstOrDefaultAsync();
            return usuarios;
        }

        public async Task<Usuarios> GetUsuario(string nombreUsuario)
        {
            return await _context.usuarios.FirstOrDefaultAsync(u => u.Nombre == nombreUsuario);
        }

        public async Task<Usuarios> SaveUsuario(Usuarios nombre)
        {
            _context.usuarios.Add(nombre);
            await _context.SaveChangesAsync();
            return nombre;
        }
    }
}
