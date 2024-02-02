using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRosty.Models;

namespace ProyectoRosty.Services
{

    public class ServicioLista : IServicioLista
    {
        private readonly LibreriaContext _context;

        public ServicioLista(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaGestiones()
        {
            List<SelectListItem> list = await _context.GestionDeGaseosas.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.IdGestion}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un bebiba...]",
                Value = "0"
            });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaProductos()
        {
            List<SelectListItem> list = await _context.bodegas.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.IdProducto}"
            })
               .OrderBy(x => x.Text)
               .ToListAsync();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un producto...]",
                Value = "0"
            });
            return list;
        }
    }

}