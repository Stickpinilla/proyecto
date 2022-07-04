using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class IndexViewModel
    {

        public List<Producto> ListaProductos { get; set; }

        public int CantidadPagina { get; set; }

        public int Pagina { get; set; }
    }
}
