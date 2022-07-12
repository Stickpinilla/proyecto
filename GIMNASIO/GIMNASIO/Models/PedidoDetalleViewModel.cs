using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class PedidoDetalleViewModel
    {
        public Pedido Pedido { get; set; }

        public MetodoPago metodo { get; set; }

        public PedidoEstado PedidoEstado { get; set; }
        public List<PedidoDetalle> ListaDetalle { get; set; }
    }
}
