using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Controllers
{
    public class RolesController : Controller
    {
        private readonly LibreriaContext _context;

        public RolesController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoRoles()
        {
            return View(await _context.roles.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Roles roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Rol Creado Exitosamente";
                return RedirectToAction("ListadoRoles");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.roles == null)
            {
                return NotFound();
            }

            var roles = await _context.roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Roles roles)
        {
            if (id != roles.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Rol Actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoRoles");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(roles);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.roles == null)
            {
                return NotFound();
            }
            var roles = await _context.roles
                .FirstOrDefaultAsync(n => n.IdRol == id);

            if (roles == null)
            {
                return NotFound();
            }
            try
            {
                _context.roles.Remove(roles);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Rol eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoRoles));

        }
    }
}
