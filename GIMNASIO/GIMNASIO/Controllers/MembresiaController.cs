using GIMNASIO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var Cliente = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            var Membresia = _context.tblMembresia
                .Where(m => m.Cliente.Id == Cliente.Id)
                .Include(m => m.TipoMembresia)
                .Include(m => m.EstadoMembresia)
                .Include(m => m.MetodoPagoMembresia)
                .ToList();
            return View(Membresia);
        }
    }
}
