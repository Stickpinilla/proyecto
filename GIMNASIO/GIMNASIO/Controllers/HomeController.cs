
using GIMNASIO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public HomeController(AppDbContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
        }

        public IActionResult Index(int page)
        {
            ViewData["CategoriaId"] = new SelectList(_context.tblCategorias.ToList(), "CategoriaId", "Nombre");
            IndexViewModel indexViewModel = new IndexViewModel();

            if (page == 0)
            {
                indexViewModel.Pagina = 1;
            }
            else
            {
                indexViewModel.Pagina = page;
            }

            int muestra = 6;
            int cantidad = _context.tblProductos.ToList().Count / muestra;
            if (cantidad % muestra == 0)
            {
                indexViewModel.CantidadPagina = cantidad;
            }
            else
            {
                indexViewModel.CantidadPagina = cantidad + 1;
            }

            indexViewModel.ListaProductos = _context.tblProductos.Include(e => e.Categoria)
                .Include(e => e.Estado)
                .Skip((indexViewModel.Pagina - 1) * muestra)
                .Take(6).ToList();
            TempData["NextPage"] = indexViewModel.Pagina + 1;
            TempData["PreviusPage"] = indexViewModel.Pagina - 1;
            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Producto(int ProductoId)
        {
            return View(_context.tblProductos.Where(p => p.ProductoId.Equals(ProductoId)).
                Include(e => e.Categoria)
                .Include(e => e.Estado).ToList());
        }


        public IActionResult Search(int page, Categoria C)
        {
            ViewData["CategoriaId"] = new SelectList(_context.tblCategorias.ToList(), "CategoriaId", "Nombre");
            IndexViewModel indexViewModel = new IndexViewModel();

            if (page == 0)
            {
                indexViewModel.Pagina = 1;
            }
            else
            {
                indexViewModel.Pagina = page;
            }

            int muestra = 6;
            int cantidad = _context.tblProductos.ToList().Count / muestra;
            if (cantidad % muestra == 0)
            {
                indexViewModel.CantidadPagina = cantidad;
            }
            else
            {
                indexViewModel.CantidadPagina = cantidad + 1;
            }

            indexViewModel.ListaProductos = _context.tblProductos.Include(e => e.Categoria)
                .Include(e => e.Estado)
                .Where(p => p.CategoriaId == C.CategoriaId)
                .Skip((indexViewModel.Pagina - 1) * muestra)
                .Take(6).ToList();
            TempData["NextPage"] = indexViewModel.Pagina + 1;
            TempData["PreviusPage"] = indexViewModel.Pagina - 1;
            return View(indexViewModel);
        }

    }
}
