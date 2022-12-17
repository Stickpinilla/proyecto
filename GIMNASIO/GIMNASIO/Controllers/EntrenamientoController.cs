using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyEntrenador")]
    public class EntrenamientoController : Controller
    {

        private readonly AppDbContext _context;

        public EntrenamientoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ListarEntrenamiento(EventArgs e)
        {
            EntrenamientoViewModel listaren = new EntrenamientoViewModel();

            listaren.ListarEntrenamiento = _context.tblEntrenamiento
                .Include(e => e.entrenamientocategoria)
               .Include(e => e.entrenamientoestado)
               .Include(e => e.entrenamientozona).ToList();
            return View(listaren);
        }


        public IActionResult CrearEntrenamiento()
        {
            ViewData["EntrenamientoZonaId"] = new SelectList(_context.tblEntrenamientoZona.ToList(), "EntrenamientoZonaId", "EntrenamientoZona_Nombre");
            ViewData["EntrenamientoEstadoId"] = new SelectList(_context.tblEntrenamientoEstado.ToList(), "EntrenamientoEstadoId", "Entrenamiento_NombreEstado");
            ViewData["EntrenamientoCategoriaId"] = new SelectList(_context.tblEntrenamientoCategoria.ToList(), "EntrenamientoCategoriaId", "EntrenamientoCategoria_Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEntrenamiento(Entrenamiento E)
        {
            if (ModelState.IsValid)
            {
                _context.Add(E);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction(nameof(ListarEntrenamiento));
            }
            return View(E);
        }

        //Eliminar
        [HttpGet]
        public IActionResult EliminarEntrenamiento(int EntrenamientoId)
        {
            ViewData["EntrenamientoZonaId"] = new SelectList(_context.tblEntrenamientoZona.ToList(), "EntrenamientoZonaId", "EntrenamientoZona_Nombre");
            ViewData["EntrenamientoEstadoId"] = new SelectList(_context.tblEntrenamientoEstado.ToList(), "EntrenamientoEstadoId", "Entrenamiento_NombreEstado");
            ViewData["EntrenamientoCategoriaId"] = new SelectList(_context.tblEntrenamientoCategoria.ToList(), "EntrenamientoCategoriaId", "EntrenamientoCategoria_Nombre");
            var E = _context.tblEntrenamiento.Where(e => e.EntrenamientoId.Equals(EntrenamientoId))
               .Include(e => e.entrenamientocategoria)
               .Include(e => e.entrenamientoestado)
               .Include(e => e.entrenamientozona).FirstOrDefault();
            return View(E);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarEntrenamiento(Entrenamiento E)
        {
            var EntrenamientoEliminado = _context.tblEntrenamiento.Where(e => e.EntrenamientoId == E.EntrenamientoId).FirstOrDefault();
            _context.Entry(EntrenamientoEliminado).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Entrenamiento Eliminado Exitosamente!";
            return RedirectToAction(nameof(ListarEntrenamiento));
        }

    }
}
