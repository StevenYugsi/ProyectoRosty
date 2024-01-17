using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Controllers
{
    public class GestionesController : Controller
    {
        private readonly LibreriaContext _context;

        public GestionesController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoGestiones()
        {
            return View(await _context.GestionDeGaseosas.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(GestionDeGaseosas gestionDeGaseosas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionDeGaseosas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Gestion Creada Exitosamente";
                return RedirectToAction("ListadoGestiones");
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
            if (id == null || _context.GestionDeGaseosas == null)
            {
                return NotFound();
            }

            var gestionDeGaseosas = await _context.GestionDeGaseosas.FindAsync(id);
            if (gestionDeGaseosas == null)
            {
                return NotFound();
            }
            return View(gestionDeGaseosas);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, GestionDeGaseosas gestionDeGaseosas)
        {
            if (id != gestionDeGaseosas.IdGestion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionDeGaseosas);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Gestion actualizada " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoGestiones");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(gestionDeGaseosas);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.GestionDeGaseosas == null)
            {
                return NotFound();
            }
            var gestionDeGaseosas = await _context.GestionDeGaseosas
                .FirstOrDefaultAsync(n => n.IdGestion == id);

            if (gestionDeGaseosas == null)
            {
                return NotFound();
            }
            try
            {
                _context.GestionDeGaseosas.Remove(gestionDeGaseosas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Gestion eliminada exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoGestiones));

        }
    }
}
