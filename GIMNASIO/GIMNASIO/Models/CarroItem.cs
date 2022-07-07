using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class CarroItem
    {
        public int CarroItemId { get; set; }

        public int CarroCantidad { get; set; }

        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        public string CarroCompraId { get; set; }

    }
}
