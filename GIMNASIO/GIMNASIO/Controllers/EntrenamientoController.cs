using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class EntrenamientoController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;

        public EntrenamientoController(UserManager<Cliente> userManager, SignInManager<Cliente> signInManager, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ListarEntrenamiento(EventArgs e)
        {
            EntrenamientoViewModel listaren = new EntrenamientoViewModel();

            listaren.ListarEntrenamiento = _context.tblEntrenamiento
                .Include(e => e.entrenamientocategoria)
               .Include(e => e.entrenamientoestado)
               .Include(e => e.entrenamientozona)
               .ToList();
            return View(listaren);
        }


        public IActionResult CrearEntrenamiento()
        {
            ViewData["EntrenamientoZonaId"] = new SelectList(_context.tblEntrenamientoZona.Where(z => z.EntrenamientoZona_Disponibilidad == true).ToList(), "EntrenamientoZonaId", "EntrenamientoZona_Nombre");
            ViewData["EntrenamientoEstadoId"] = new SelectList(_context.tblEntrenamientoEstado.ToList(), "EntrenamientoEstadoId", "Entrenamiento_NombreEstado");
            ViewData["EntrenamientoCategoriaId"] = new SelectList(_context.tblEntrenamientoCategoria.ToList(), "EntrenamientoCategoriaId", "EntrenamientoCategoria_Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEntrenamiento(Entrenamiento E)
        {
            var Cliente = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                E.Cliente = Cliente;
                E.EntrenamientoCupoDisponible = E.EntrenamientoCupoTotal;
                _context.Add(E);
                var ZonaEntrenamiento = _context.tblEntrenamientoZona
                    .Where(z => z.EntrenamientoZonaId == E.EntrenamientoZonaId)
                    .FirstOrDefault();
                ZonaEntrenamiento.EntrenamientoZona_Disponibilidad = false;
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction(nameof(ListarEntrenamiento));
            }
            return View(E);
        }



        public IActionResult CrearEntrenamientoAdmin()
        {
            ViewData["EntrenadorId"] = new SelectList(_context.Users.Where(t => t.Tipo == "Entrenador").ToList(), "Id", "Rut");
            ViewData["EntrenamientoZonaId"] = new SelectList(_context.tblEntrenamientoZona.Where(z => z.EntrenamientoZona_Disponibilidad == true).ToList(), "EntrenamientoZonaId", "EntrenamientoZona_Nombre");
            ViewData["EntrenamientoEstadoId"] = new SelectList(_context.tblEntrenamientoEstado.ToList(), "EntrenamientoEstadoId", "Entrenamiento_NombreEstado");
            ViewData["EntrenamientoCategoriaId"] = new SelectList(_context.tblEntrenamientoCategoria.ToList(), "EntrenamientoCategoriaId", "EntrenamientoCategoria_Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEntrenamientoAdmin(EntrenamientoUsuarioViewModel E)
        {
            Entrenamiento en = new Entrenamiento();
            if (ModelState.IsValid)
            {
                var Cliente = _context.Users.Where(e => e.Id == E.EntrenadorID).FirstOrDefault();
                en.EntrenamientoCupoDisponible = E.Entrenamiento.EntrenamientoCupoTotal;
                en.EntrenamientoCupoTotal = E.Entrenamiento.EntrenamientoCupoTotal;
                en.EntrenamientoDescripcion = E.Entrenamiento.EntrenamientoDescripcion;
                en.EntrenamientoEstadoId = E.Entrenamiento.EntrenamientoEstadoId;
                en.EntrenamientoCategoriaId = E.Entrenamiento.EntrenamientoCategoriaId;
                en.EntrenamientoZonaId = E.Entrenamiento.EntrenamientoZonaId;
                en.Cliente = Cliente;
                _context.Add(en);
                var ZonaEntrenamiento = _context.tblEntrenamientoZona
                    .Where(z => z.EntrenamientoZonaId == E.Entrenamiento.EntrenamientoZonaId)
                    .FirstOrDefault();
                ZonaEntrenamiento.EntrenamientoZona_Disponibilidad = false;
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
            var ZonaActual = _context.tblEntrenamientoZona
                    .Where(za => za.EntrenamientoZonaId == E.EntrenamientoZonaId)
                    .FirstOrDefault();
            ZonaActual.EntrenamientoZona_Disponibilidad = true;
            _context.Entry(EntrenamientoEliminado).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Entrenamiento Eliminado Exitosamente!";
            return RedirectToAction(nameof(ListarEntrenamiento));
        }

        //Editar Entrenamiento  
        public IActionResult ModificarEntrenamiento(int EntrenamientoId)
        {
            ViewData["EntrenamientoZonaId"] = new SelectList(_context.tblEntrenamientoZona.ToList(), "EntrenamientoZonaId", "EntrenamientoZona_Nombre");
            ViewData["EntrenamientoEstadoId"] = new SelectList(_context.tblEntrenamientoEstado.ToList(), "EntrenamientoEstadoId", "Entrenamiento_NombreEstado");
            ViewData["EntrenamientoCategoriaId"] = new SelectList(_context.tblEntrenamientoCategoria.ToList(), "EntrenamientoCategoriaId", "EntrenamientoCategoria_Nombre");
            var E = _context.tblEntrenamiento.Where(e => e.EntrenamientoId.Equals(EntrenamientoId)).FirstOrDefault();
            return View(E);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarEntrenamiento(Entrenamiento E)
        {
            if (ModelState.IsValid)
            {
                var EntrenamientoModificada = _context.tblEntrenamiento.Where(e => e.EntrenamientoId.Equals(e.EntrenamientoId)).FirstOrDefault();

                var ZonaActual = _context.tblEntrenamientoZona
                    .Where(za => za.EntrenamientoZonaId == EntrenamientoModificada.EntrenamientoZonaId)
                    .FirstOrDefault();
                var ZonaNueva = _context.tblEntrenamientoZona
                    .Where(zn => zn.EntrenamientoZonaId == E.EntrenamientoZonaId)
                    .FirstOrDefault();

                EntrenamientoModificada.EntrenamientoCupoTotal = E.EntrenamientoCupoTotal;
                EntrenamientoModificada.EntrenamientoCupoDisponible = E.EntrenamientoCupoDisponible;
                EntrenamientoModificada.EntrenamientoDescripcion = E.EntrenamientoDescripcion;
                EntrenamientoModificada.EntrenamientoEstadoId = E.EntrenamientoEstadoId;
                EntrenamientoModificada.EntrenamientoZonaId = E.EntrenamientoZonaId;
                EntrenamientoModificada.EntrenamientoCategoriaId = E.EntrenamientoCategoriaId;

                ZonaActual.EntrenamientoZona_Disponibilidad = true;
                ZonaNueva.EntrenamientoZona_Disponibilidad = false;

                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Entrenamiento Modificado Exitosamente!";
                return RedirectToAction(nameof(ListarEntrenamiento));
            }
            else
            {
                return View(E);
            }
        }

        public IActionResult DetalleEntrenamiento(int EntrenamientoId)
        {
            EntrenamientoUsuarioViewModel euvm = new EntrenamientoUsuarioViewModel();

            euvm.Entrenamiento = _context.tblEntrenamiento
               .Include(e => e.entrenamientocategoria)
               .Include(e => e.entrenamientoestado)
               .Include(e => e.entrenamientozona)
               .Where(e => e.EntrenamientoId == EntrenamientoId)
               .FirstOrDefault();

            euvm.ListaEntrenamiento = _context.tblEntrenamientoUsuario
                .Include(eu => eu.Cliente)
                .Where(eu => eu.EntrenamientoId == EntrenamientoId && eu.Cliente.Tipo == "Cliente")
                .ToList();
            return View(euvm);
        }

        public async Task<IActionResult> EliminarClienteDeEntrenamiento(int EntrenamientoId, string ClienteId)
        {
            var EntrenamientoUsuario = _context.tblEntrenamientoUsuario
                .Include(eu => eu.entrenamiento)
                .Include(eu => eu.Cliente)
                .Where(eu => eu.Cliente.Id == ClienteId && eu.entrenamiento.EntrenamientoId == EntrenamientoId)
                .FirstOrDefault();
            _context.Entry(EntrenamientoUsuario).State = EntityState.Deleted;

            var Entrenamiento = _context.tblEntrenamiento.Where(e => e.EntrenamientoId == EntrenamientoId).FirstOrDefault();
            Entrenamiento.EntrenamientoCupoDisponible++;

            if (Entrenamiento.EntrenamientoCupoDisponible > 10)
            {
                Entrenamiento.EntrenamientoEstadoId = 1;
            }
            if (Entrenamiento.EntrenamientoCupoDisponible > 0 && Entrenamiento.EntrenamientoCupoDisponible <= 10)
            {
                Entrenamiento.EntrenamientoEstadoId = 2;
            }


            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Cliente Borrado del Entrenamiento!";
            return RedirectToAction("DetalleEntrenamiento", new { EntrenamientoId = EntrenamientoId });

        }

    }
}
