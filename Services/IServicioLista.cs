using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoRosty.Services
{
        public interface IServicioLista
        {
            Task<IEnumerable<SelectListItem>>
                GetListaGestiones();
            Task<IEnumerable<SelectListItem>>
                GetListaProductos();
            //Task<IEnumerable<SelectListItem>>
            //    GetListaRoles();
        }
}
