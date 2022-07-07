using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class CarroCompra
    {
        private readonly AppDbContext _context;

        public string CarroCompraId { get; set; }

        public List<CarroItem> CarroItems { get; set; }

        public CarroCompra (AppDbContext context)
        {
            _context = context;
        }

        public static CarroCompra GetCarroCompra(IServiceProvider services)
        {
            //para la sesion 
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;
            //Contexto de datos
            var context = services.GetService<AppDbContext>();
            //Generar el carro Id
            string CarroId = session.GetString("CarroId") ?? Guid.NewGuid().ToString();
            session.SetString("CarroId", CarroId);
            return new CarroCompra(context) { CarroCompraId = CarroId };
        }

        //añadir productos al carro
        public void AddItem(Producto P)
        {
            var item = _context.tblCarroItem
                 .Where(i => i.ProductoId == P.ProductoId && i.CarroCompraId == this.CarroCompraId)
                 .FirstOrDefault();

            if (item == null)
            {
                //no ha sido agregado el mismo producto al carro
                CarroItem carroItem = new CarroItem()
                {
                    Producto = P,
                    CarroCantidad = 1,
                    CarroCompraId = this.CarroCompraId,
                    ProductoId = P.ProductoId
                };
                _context.Add(carroItem);
            }
            else
            {
                item.CarroCantidad++;
            }
            _context.SaveChanges();
        }

        //eliminar el carro
        public void delItem(Producto P)
        {
            var item = _context.tblCarroItem
                 .Where(i => i.ProductoId == P.ProductoId && i.CarroCompraId == this.CarroCompraId)
                 .FirstOrDefault();
            //Por si quiero eliminar por cantidad
            _context.Remove(item);
            _context.SaveChanges();
        }

        //Mostrar el carro
        public List<CarroItem> GetCarroItems()
        {
            return _context.tblCarroItem
                .Where(i => i.CarroCompraId == this.CarroCompraId)
                .Include(i => i.Producto).ToList();
        }

        //eliminar carro por Completo
        public void VaciarCarro()
        {
            var items = _context.tblCarroItem
                .Where(i => i.CarroCompraId == this.CarroCompraId)
                .ToList();
            _context.tblCarroItem.RemoveRange(items);
            _context.SaveChanges();
        }

        //calcular el total
        public double GetTotalCarro()
        {
            return _context.tblCarroItem.Where(i => i.CarroCompraId == this.CarroCompraId)
                .Select(i => i.Producto.ProductoPrecio * i.CarroCantidad).Sum();
        }


        //sumar dentro del carro
        public void AddCarro(Producto P)
        {
            var item = _context.tblCarroItem
                .Where(i => i.ProductoId == P.ProductoId && i.CarroCompraId == this.CarroCompraId)
                .FirstOrDefault();

            item.CarroCantidad++;
            _context.SaveChanges();
        }

        public void delCarro(Producto P)
        {
            var item = _context.tblCarroItem
                .Where(i => i.ProductoId == P.ProductoId && i.CarroCompraId == this.CarroCompraId)
                .FirstOrDefault();
            //por si quiero eliminar por cantidad 

            if (item.CarroCantidad <= 1)
            {
                _context.Remove(item);
            }
            else
            {
                item.CarroCantidad--;
            }
            _context.SaveChanges();

        }

    }
}
