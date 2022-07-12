using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class PedidoViewModel
    {
        public string Id { get; set; }
        public Cliente cliente { get; set; }
        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public List<CarroItem> carroItems { get; set; }

        public double Total { get; set; }
    }
}
