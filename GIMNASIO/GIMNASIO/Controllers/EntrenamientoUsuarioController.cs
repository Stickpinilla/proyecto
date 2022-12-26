using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyCliente")]
    public class EntrenamientoUsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;
        public EntrenamientoUsuarioController(UserManager<Cliente> userManager, SignInManager<Cliente> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult ListarEntrenamiento(EventArgs e)
        {
            EntrenamientoViewModel listaren = new EntrenamientoViewModel();

            listaren.ListarEntrenamiento = _context.tblEntrenamiento
                .Include(e => e.entrenamientocategoria)
               .Include(e => e.entrenamientoestado)
               .Include(e => e.entrenamientozona).Where(e => e.EntrenamientoEstadoId == 1 && e.EntrenamientoCupoDisponible > 0).ToList();
            return View(listaren);
        }

        public async Task<IActionResult> EntrenamiendoAnadir(EntrenamientoUsuario EN, int EntrenamientoId)
        {
            var Cliente = await _userManager.GetUserAsync(HttpContext.User);
            var Entrenamiento = _context.tblEntrenamiento.Where(e => e.EntrenamientoId.Equals(EntrenamientoId)).FirstOrDefault();
            if (ModelState.IsValid)
            {

                EN.Cliente = Cliente;
                EN.entrenamiento = Entrenamiento;
                _context.Add(EN);
                Entrenamiento.EntrenamientoCupoDisponible--;
                if (Entrenamiento.EntrenamientoCupoDisponible <= 10)
                {
                    Entrenamiento.EntrenamientoEstadoId = 2;
                }
                if (Entrenamiento.EntrenamientoCupoDisponible == 0)
                {
                    Entrenamiento.EntrenamientoEstadoId = 4;
                }

                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction(nameof(ListarEntrenamiento));
            }
            return View(EN);
        }

  

        public async Task<IActionResult> MisEntrenamientos()
        {
            var Cliente = await _userManager.GetUserAsync(HttpContext.User);
            EntrenamientoUsuarioViewModel EU = new EntrenamientoUsuarioViewModel
            {
                cliente = Cliente,
                ListaEntrenamiento = _context.tblEntrenamientoUsuario
                .Where(e => e.Cliente.Id == Cliente.Id)
                .Include(c => c.entrenamiento.entrenamientocategoria)
               .Include(e => e.entrenamiento.entrenamientoestado)
               .Include(e => e.entrenamiento.entrenamientozona)
               .ToList()
            };
            return View(EU);
        }




    }
}
