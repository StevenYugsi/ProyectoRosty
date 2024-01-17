using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly LibreriaContext _context;

        public RegistrosController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoRegistro()
        {
            return View(await _context.RegistroDeVentas.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(RegistroDeVentas registroDeVentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDeVentas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Registro de Venta Creado Exitosamente";
                return RedirectToAction("ListadoRegistro");
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
            if (id == null || _context.RegistroDeVentas == null)
            {
                return NotFound();
            }

            var registroDeVentas = await _context.RegistroDeVentas.FindAsync(id);
            if (registroDeVentas == null)
            {
                return NotFound();
            }
            return View(registroDeVentas);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, RegistroDeVentas registroDeVentas)
        {
            if (id != registroDeVentas.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDeVentas);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Registro de Venta actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoRegistro");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(registroDeVentas);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.RegistroDeVentas == null)
            {
                return NotFound();
            }
            var registroDeVentas = await _context.RegistroDeVentas
                .FirstOrDefaultAsync(n => n.IdVenta == id);

            if (registroDeVentas == null)
            {
                return NotFound();
            }
            try
            {
                _context.RegistroDeVentas.Remove(registroDeVentas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Registro de Venta eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoRegistro));

        }
    }
}
