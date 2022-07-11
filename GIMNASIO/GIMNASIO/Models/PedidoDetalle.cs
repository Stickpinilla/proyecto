using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class PedidoDetalle
    {
        public int PedidoDetalleId { get; set; }

        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public int Cantidad { get; set; }
    }
}
