using GIMNASIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class CarroController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CarroCompra _carro;

        public CarroController(AppDbContext context, CarroCompra carro)
        {
            _context = context;
            _carro = carro;
        }

        public IActionResult Index()
        {
            ViewData["MetodoPagoId"] = new SelectList(_context.tblMetodoPago.ToList(), "MetodoPagoId", "MetodoNombre");
            ViewData["Id"] = new SelectList(_context.Users.Where(t => t.Tipo == "Cliente").ToList(), "Id", "Rut");
            CarroCompraViewModel carroCompraViewModel = new CarroCompraViewModel()
            {
                carroItems = _carro.GetCarroItems(),
                TotalCarro = _carro.GetTotalCarro()
            };
            return View(carroCompraViewModel);
        }

        public RedirectToActionResult Add(int ProductoId)
        {
            ViewData["MetodoPagoId"] = new SelectList(_context.tblMetodoPago.ToList(), "MetodoPagoId", "MetodoNombre");
            ViewData["id"] = new SelectList(_context.Users.Where(t => t.Tipo.Equals("Cliente")).ToList(), "id", "Rut");
            var P = _context.tblProductos.Where(p => p.ProductoId == ProductoId).FirstOrDefault();
            if (P != null)
            {
                _carro.AddItem(P);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult Del(int ProductoId)
        {
            var P = _context.tblProductos.Where(p => p.ProductoId == ProductoId).FirstOrDefault();
            if (P != null)
            {
                _carro.delItem(P);
            }
            return RedirectToAction(nameof(Index));
        }


        public RedirectToActionResult AddCart(int ProductoId)
        {
            var P = _context.tblProductos.Where(p => p.ProductoId == ProductoId).FirstOrDefault();
            if (P != null)
            {
                _carro.AddCarro(P);
            }
            return RedirectToAction(nameof(Index));
        }


        public RedirectToActionResult DelCart(int ProductoId)
        {
            var P = _context.tblProductos.Where(p => p.ProductoId == ProductoId).FirstOrDefault();
            if (P != null)
            {
                _carro.delCarro(P);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
