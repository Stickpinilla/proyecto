using GIMNASIO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CarroCompra _carro;
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;

        public PedidoController(AppDbContext context, CarroCompra carro,
            UserManager<Cliente> userManager, SignInManager<Cliente> signInManager)
        {
            _context = context;
            _carro = carro;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var Cliente = await _userManager.GetUserAsync(HttpContext.User);
            var items = _carro.GetCarroItems();
            var total = _carro.GetTotalCarro();
            PedidoViewModel Pvm = new PedidoViewModel
            {
                cliente = Cliente,
                carroItems = items,
                Total = total
            };
            await _context.SaveChangesAsync();
            return View(Pvm);
        }

    }
}
