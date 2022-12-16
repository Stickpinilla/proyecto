using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyAdmin")]
    public class MantencionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;

        public MantencionController(AppDbContext context, UserManager<Cliente> userManager, SignInManager<Cliente> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult AgregarMantencionPorMaquina(int MaquinaId)
        {
            MaquinariaMantencionViewModel mmvm = new MaquinariaMantencionViewModel();
            mmvm.Maquinaria = _context.tblMaquinaria
                .Where(m => m.MaquinariaId == MaquinaId)
                .Include(m => m.TipoMaquinaria)
                .Include(m => m.EstadoMaquinaria)
                .FirstOrDefault();

            mmvm.MaquinariaId = MaquinaId;
            mmvm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewData["EstadoMantencionId"] = new SelectList(_context.tblEstadoMantencion.ToList(), "EstadoMantencionId", "EstadoMantencionNombre");

            return View(mmvm);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMantencionPorMaquina(MaquinariaMantencionViewModel M)
        {
            var UsuarioLogeado = _context.Users.Where(u => u.Id.Equals(M.UserId)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Mantencion m = new Mantencion();
                m.MantencionFechaIngreso = DateTime.Now;
                m.EstadoMantencionId = M.EstadoMantencionId;
                m.MantencionDescripcion = M.MantencionDescripcion;
                m.MaquinariaId = M.MaquinariaId;
                m.Cliente = UsuarioLogeado;
                _context.Add(m);

                var Maquina = _context.tblMaquinaria
                    .Where(m => m.MaquinariaId == M.MaquinariaId)
                    .FirstOrDefault();
                Maquina.EstadoMaquinariaId = 3;
                await _context.SaveChangesAsync();



                TempData["Mensaje"] = "Mantencion Agregado Exitosamente!";
                return RedirectToAction("ListaMantencion", new { EstadoId = 1 });
            }
            return View(M);
        }

        [HttpGet]
        public IActionResult ListaMantencion(int EstadoId)
        {
            int estado = 1;
            if (EstadoId != estado)
            {
                estado = EstadoId;
            }
            var lista = _context.tblMantencion
                .Where(m => m.EstadoMantencionId == estado)
                .Include(m => m.EstadoMantencion)
                .Include(m => m.Maquinaria)
                .ToList();
            TempData["Estado"] = estado;
            return View(lista);
        }

        [HttpGet]
        public IActionResult ModificarMantencion(int MantencionId)
        {
            var Mantencion = _context.tblMantencion
                .Where(m => m.MantencionId == MantencionId)
                .Include(m => m.EstadoMantencion)
                .Include(m => m.Maquinaria)
                .FirstOrDefault();

            ViewData["EstadoMantencionId"] = new SelectList(_context.tblEstadoMantencion.ToList(), "EstadoMantencionId", "EstadoMantencionNombre");
            return View(Mantencion);
        }
    }
}
