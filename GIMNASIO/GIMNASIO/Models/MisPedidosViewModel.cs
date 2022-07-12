using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class MisPedidosViewModel
    {
        public Cliente cliente { get; set; }

        public List<Pedido> ListaPedidos { get; set; }
    }
}
