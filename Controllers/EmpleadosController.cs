using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;

namespace ProyectoRosty.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly LibreriaContext _context;

        public EmpleadosController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoEmpleados()
        {
            return View(await _context.empleados.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Empleado Creado Exitosamente";
                return RedirectToAction("ListadoEmpleados");
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
            if (id == null || _context.empleados == null)
            {
                return NotFound();
            }

            var empleados = await _context.empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Empleados empleados)
        {
            if (id != empleados.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Empleado actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoEmpleados");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(empleados);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.empleados == null)
            {
                return NotFound();
            }
            var empleados = await _context.empleados
                .FirstOrDefaultAsync(n => n.IdEmpleado == id);

            if (empleados == null)
            {
                return NotFound();
            }
            try
            {
                _context.empleados.Remove(empleados);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Empleado eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se puede eliminar");

            }
            return RedirectToAction(nameof(ListadoEmpleados));

        }
    }
}
