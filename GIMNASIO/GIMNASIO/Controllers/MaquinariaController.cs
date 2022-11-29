using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyAdmin")]
    public class MaquinariaController : Controller
    {
        private readonly AppDbContext _context;

        public MaquinariaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaMaquinaria(int page)
        {
            ViewData["TipoId"] = new SelectList(_context.tblTipoMaquinaria.ToList(), "TipoMaquinariaId", "TipoMaquinariaNombre");
            ViewData["EstadoId"] = new SelectList(_context.tblEstadoMaquinaria.ToList(), "EstadoMaquinariaId", "EstadoMaquinariaNombre");
            MaquinariaViewModel viewModel = new MaquinariaViewModel();
            if (page == 0)
            {
                viewModel.Pagina = 1;
            }
            else
            {
                viewModel.Pagina = page;
            }

            int muestra = 6;
            int cantidad = _context.tblMaquinaria.ToList().Count / muestra;
            if (cantidad % muestra == 0)
            {
                viewModel.CantidadPagina = cantidad;
            }
            else
            {
                viewModel.CantidadPagina = cantidad + 1;
            }

            viewModel.ListaMaquinaria = _context.tblMaquinaria.Include(m => m.TipoMaquinaria)
                .Include(m => m.EstadoMaquinaria)
                .Skip((viewModel.Pagina - 1) * muestra)
                .Take(6).ToList();
            TempData["NextPage"] = viewModel.Pagina + 1;
            TempData["PreviusPage"] = viewModel.Pagina - 1;
            return View(viewModel);
        }
    }
}
