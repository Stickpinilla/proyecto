using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class IndexViewModel
    {

        public List<Producto> ListaProductos { get; set; }

        public int CantidadPagina { get; set; }

        public int Pagina { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
