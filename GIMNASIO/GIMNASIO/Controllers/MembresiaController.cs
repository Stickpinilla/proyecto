using GIMNASIO.Models;
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
    public class MembresiaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;

        public MembresiaController(UserManager<Cliente> userManager, SignInManager<Cliente> signInManager,
            AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ListarMembresia(Cliente C)
        {

            MembresiaViewModel mvm = new MembresiaViewModel();
            var Cliente = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            mvm.ListaMembresias = _context.tblMembresia
                .Where(m => m.Cliente.Id == Cliente.Id)
                .Include(m => m.TipoMembresia)
                .Include(m => m.EstadoMembresia)
                .Include(m => m.MetodoPagoMembresia)
                .Include(m => m.Cliente)
                .ToList();
            mvm.Id = Cliente.Id;
            return View(mvm);
        }

        public IActionResult AgregarMembresia(string ClienteId) 
        {
            var cliente = _context.Users.Where(c => c.Id == ClienteId).FirstOrDefault();

            MembresiaViewModel mvm = new MembresiaViewModel
            {

                Id = cliente.Id
            };

            ViewData["MetodoPagoMembresiaId"] = new SelectList(_context.tblMetodoPagoMembresia.ToList(), "MetodoPagoMembresiaId", "MetodoPagoMembresiaNombre");
            ViewData["EstadoMembresiaId"] = new SelectList(_context.tblEstadoMembresia.ToList(), "EstadoMembresiaId", "EstadoMembresiaNombre");
            ViewData["TipoMembresiaId"] = new SelectList(_context.tblTipoMembresia.ToList(), "TipoMembresiaId", "TipoMembresiaNombre");
            return View(mvm);
        }

        [HttpPost]
        public IActionResult AgregarMembresia(MembresiaViewModel M)
        {
            var C = _context.Users.Where(c => c.Id == M.Id).FirstOrDefault();

                Membresia membresia = new Membresia();
                var MembresiaMetodoPago = _context.tblMetodoPagoMembresia.Where(mp => mp.MetodoPagoMembresiaId == M.MetodoPagoMembresiaId).FirstOrDefault();
                var TipoMembresia = _context.tblTipoMembresia.Where(tm => tm.TipoMembresiaId == M.TipoMembresiaId).FirstOrDefault();
                var EstadoMembresia = _context.tblEstadoMembresia.Where(em => em.EstadoMembresiaId == M.EstadoMembresiaId).FirstOrDefault();
                membresia.MetodoPagoMembresia = MembresiaMetodoPago;
                membresia.TipoMembresia = TipoMembresia;
                membresia.EstadoMembresia = EstadoMembresia;
                membresia.FechaComienzo = M.FechaComienzo;
                membresia.Cliente = C;
                var Months = M.FechaComienzo;
                switch (TipoMembresia.TipoMembresiaNombre) {
                    case "1 MES":
                        membresia.FechaTermino = Months.AddMonths(1);
                        break;
                    case "3 MESES":
                        membresia.FechaTermino = Months.AddMonths(3);
                        break;
                    case "12 MESES":
                        membresia.FechaTermino = Months.AddMonths(12);
                        break;
                }

                _context.Add(membresia);
                _context.SaveChanges();

            
            
            return RedirectToAction("ListarMembresia", C);
        }
    }
}
