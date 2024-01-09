using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRosty.Models.Entidades
{
    public class RegistroDeVentas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string VentasDiarias { get; set; }

        public string DetalleVenta { get; set; }
        public string FechaDeVenta { get; set; }
        public decimal TotalVenta { get; set; }

        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public int idGestion {  get; set; } 
        public Bodega Bodega { get; set; }
        public Clientes Cliente { get; set; }
        public GestionDeGaseosas GestionDeGaseosas { get; set; }
    }
}

