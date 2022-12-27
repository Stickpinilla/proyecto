using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class MisAvancesViewModel
    {
        public Cliente cliente { get; set; }
        public List<AvanceCliente> ListaAvances { get; set; }

    }
}
