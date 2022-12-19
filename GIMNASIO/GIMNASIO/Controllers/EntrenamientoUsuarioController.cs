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
               .Include(e => e.entrenamientozona).ToList();
            return View(listaren);
        }

        public async Task<IActionResult> EntrenamiendoAnadir(EntrenamientoUsuario P, IServiceProvider services, Cliente C)
        {
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;

            var Cliente = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            var Entrana = _context.tblEntrenamiento.Where(c => c.EntrenamientoId == P.EntrenamientoId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                _context.Add(P);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction(nameof(ListarEntrenamiento));
            }
            return View(P);
        
        }



    }
}
