using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
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

        public MantencionController(AppDbContext context)
        {
            _context = context;
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
            //mmvm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewData["EstadoMantencionId"] = new SelectList(_context.tblEstadoMantencion.ToList(), "EstadoMantencionId", "EstadoMantencionNombre");

            return View(mmvm);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMantencionPorMaquina(Mantencion M)
        {
            if (ModelState.IsValid)
            {
                _context.Add(M);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction("ListaMaquinaria", new { EstadoId = 1 });
            }
            return View(M);
        }
    }
}
