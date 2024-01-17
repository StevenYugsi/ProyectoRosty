using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRosty.Models.Entidades
{
    public class GestionDeGaseosas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGestion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string FechaIngreso { get; set; }    
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
    }

}
