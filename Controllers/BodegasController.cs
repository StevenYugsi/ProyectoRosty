using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Controllers
{
    public class BodegasController : Controller
    {
        private readonly LibreriaContext _context;

        public BodegasController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoBodegas()
        {
            return View(await _context.bodegas.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Producto Creado Exitosamente";
                return RedirectToAction("ListadoBodegas");
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
            if (id == null || _context.bodegas == null)
            {
                return NotFound();
            }

            var bodega = await _context.bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Bodega bodega)
        {
            if (id != bodega.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Producto actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoBodegas");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(bodega);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.bodegas == null)
            {
                return NotFound();
            }
            var bodega = await _context.bodegas
                .FirstOrDefaultAsync(n => n.IdProducto == id);

            if (bodega == null)
            {
                return NotFound();
            }
            try
            {
                _context.bodegas.Remove(bodega);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Producto eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoBodegas));

        }
    }
}
