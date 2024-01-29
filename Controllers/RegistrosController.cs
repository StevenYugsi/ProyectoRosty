using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;
using ProyectoRosty.Models.Entidades;
using ProyectoRosty.Services;

namespace ProyectoRosty.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly IServicioLista _servicioLista;

        private readonly LibreriaContext _context;

        public RegistrosController(IServicioLista servicioLista, LibreriaContext context)
        {
            _context = context;
            _servicioLista = servicioLista;
        }
        public async Task<IActionResult> ListadoRegistro()
        {
            return View(await _context.RegistroDeVentas.ToListAsync());
        }
        public IActionResult Crear()

        {

            return View();


        }
        private async Task<GestionDeGaseosas> GetGestion()
        {
            return new GestionDeGaseosas()
            {
                IdGestion = await _servicioLista.GetListaGestiones()
                //Autores = await _servicioLista.GetListaAutores(),
                //Editoriales = await _servicioLista.GetListaEditoriales()
            };
        }

        [HttpPost]
        public async Task<IActionResult> Crear(RegistroDeVentas registroDeVentas)
        {
            var gestionDeGaseosas = _context.GestionDeGaseosas.ToList();

            IEnumerable<SelectListItem> gestionSelectList = gestionDeGaseosas
                .Select(g => new SelectListItem { Value = g.IdGestion.ToString(), Text = g.Nombre });

            var modelo = new RegistroDeVentas
            {
                GestionDeGaseosas = (GestionDeGaseosas)gestionSelectList,
                // Otras propiedades de RegistroDeVentas que puedas necesitar inicializar aquí
            };

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
