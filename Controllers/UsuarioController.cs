using Microsoft.AspNetCore.Mvc;
using ProyectoRosty.Models.Entidades;
using ProyectoRosty.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoRosty.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LibreriaContext _context;

        public UsuarioController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoUsuarios()
        {
            return View(await _context.usuarios.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        public async Task<IActionResult> Crear(Usuarios usaurio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usaurio);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Usuario Creado Correctamente";
                return RedirectToAction("ListadoUsarios");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.usuarios
                .FirstOrDefaultAsync(n => n.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Usuarios usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Usuario Actualizado Correctamente!!";
                    return RedirectToAction("ListadoUsarios");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error al Actualizar");
                }
            }
            return View();
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.usuarios
                .FirstOrDefaultAsync(n => n.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            try
            {
                _context.usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Usuario eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoUsuarios));
        }
    }
}
