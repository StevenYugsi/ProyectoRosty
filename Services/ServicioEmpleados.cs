using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public class ServicioEmpleados : IServicioEmpleados
    {
        private readonly LibreriaContext _context;

        public ServicioEmpleados(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Empleados> GetEmpleados(string Nombre, string Cargo, string FechaDeContratacion, string Direccion)
        {
            Empleados empleados = await _context.empleados.Where(u => u.Nombre == Nombre && u.Cargo == Cargo && u.FechaDeContratacion == FechaDeContratacion
           && u.Direccion == Direccion).FirstOrDefaultAsync();
            return empleados;
        }

        public async Task<Empleados> GetEmpleados(string nombreEmpleado)
        {
            return await _context.empleados.FirstOrDefaultAsync(u => u.Nombre == nombreEmpleado);
        }

        public async Task<Empleados> SaveEmpleados(Empleados Nombre)
        {
            _context.empleados.Add(Nombre);
            await _context.SaveChangesAsync();
            return Nombre;
        }
    }
}
