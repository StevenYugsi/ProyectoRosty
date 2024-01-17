using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;
using ProyectoRosty.Services;
using System.Security.Claims;

namespace ProyectoRosty.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;
        private readonly LibreriaContext _context;

        public LoginController(IServicioUsuario servicioUsuario,
            IServicioImagen servicioImagen, LibreriaContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(Usuarios usuarios, IFormFile Imagen)
        {
            Stream image = Imagen.OpenReadStream();
            string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.FileName);
            usuarios.Contraseña = Utilitarios.EncriptarClave(usuarios.Contraseña);
            usuarios.URLFotoPerfil = urlImagen;

            Usuarios usuarioCreado = await _servicioUsuario.SaveUsuario(usuarios);
            if (usuarioCreado.IdUsuario > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }
            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string contraseña)
        {
            Usuarios usuarioEncontrado = await _servicioUsuario.GetUsuario(correo, Utilitarios.EncriptarClave(contraseña));
            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre),
                new Claim("FotoPerfil", usuarioEncontrado.URLFotoPerfil),

            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");
        }
    }
}

