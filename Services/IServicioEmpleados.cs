using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Services
{
    public interface IServicioEmpleados
    {
        Task<Empleados> GetEmpleados(string Nombre, string Cargo , string FechaDeContratacion, string Direccion);
        Task<Empleados> SaveEmpleados(Empleados Nombre);
        Task<Empleados> GetEmpleados(string nombreEmpleado);
    }
}
