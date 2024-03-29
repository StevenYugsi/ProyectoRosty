﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoRosty.Models.Entidades
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; } = null;
        public string? URLFotoPerfil { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        //public int idRol { get; set; }
        //public Roles roles { get; set; }
    }
}
