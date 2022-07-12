using GIMNASIO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(CarroCompraViewModel P)
        {
            var Cliente = _context.Users.Where(c => c.Id == P.Id).FirstOrDefault();
            var Metodo = _context.tblMetodoPago.Where(c => c.MetodoPagoId == P.MetodoPagoId).FirstOrDefault();
            var items = _carro.GetCarroItems();
            var total = _carro.GetTotalCarro();
            PedidoViewModel Pvm = new PedidoViewModel
            {
                cliente = Cliente,
                MetodoPago = Metodo,
                carroItems = items,
                Total = total
            };
            return View(Pvm);
        }


        public async Task<IActionResult> FinalizarPedido(CarroCompraViewModel P)
        {
            var Cliente = _context.Users.Where(c => c.Id == P.Id).FirstOrDefault();
            var Metodo = _context.tblMetodoPago.Where(c => c.MetodoPagoId == P.MetodoPagoId).FirstOrDefault();
            var items = _carro.GetCarroItems();
            var total = _carro.GetTotalCarro();
            if (items.Count > 0)
            {
                var T = _context.Database.BeginTransaction();
                try
                {
                    Pedido pedido = new Pedido
                    {
                        Cliente = Cliente,
                        MetodoPago = Metodo,
                        PedidoFecha = DateTime.Now,
                        PedidoTotal = Convert.ToInt32(total),
                        PedidoEstado = _context.tblPedidoEstado.Where(e => e.PedidoEstadoId == 1).FirstOrDefault(),
                    };

                    _context.Add(pedido);
                    _context.SaveChanges();

                    foreach (var item in items)
                    {
                        PedidoDetalle Dt = new PedidoDetalle
                        {
                            Cantidad = item.CarroCantidad,
                            PedidoId = pedido.PedidoId,
                            ProductoId = item.ProductoId
                        };
                        _context.Add(Dt);
                        _context.SaveChanges();
                    }
                    T.Commit();
                    _carro.VaciarCarro();
                }
                catch (Exception)
                {
                    T.Rollback();
                }

            }
            return RedirectToAction(nameof(PedidoCompletado));

        }

        //fin pedidooo


        public IActionResult PedidoCompletado()
        {
            return View();
        }

    }
}
