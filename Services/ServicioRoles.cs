using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public class ServicioRoles : IServicioRoles
    {
        private readonly LibreriaContext _context;

        public ServicioRoles(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Roles> GetRoles(string Rol, string Descripcion)
        {
            Roles roles = await _context.roles.Where
                  (u => u.Rol == Rol && u.Descripcion == Descripcion ).FirstOrDefaultAsync();
            return roles;
        }

        public async Task<Roles> GetRoles(string Rol)
        {
            return await _context.roles.FirstOrDefaultAsync(u => u.Rol == Rol);
        }

        public async Task<Roles> SaveRoles(Roles rol)
        {
            _context.roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
    }
}
