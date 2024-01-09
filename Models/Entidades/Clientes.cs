using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProyectoRosty.Models.Entidades
{
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int idRol { get; set; }
        public int idEmpleado {  get; set; }    
        public Roles roles { get; set; }
        public Empleados empleados { get; set; }
    }
}
