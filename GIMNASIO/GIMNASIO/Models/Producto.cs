using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Producto
    {

        public int ProductoId { get; set; }
        [DisplayName("Nombre")]
        public string ProductoNombre { get; set; }
        [DisplayName("Precio")]
        public int ProductoPrecio { get; set; }
        [DisplayName("Descripcion")]
        public string ProductoDesc { get; set; }

        public string imagen { get; set; }

        [NotMapped]
        [DisplayName("imagen")]
        public IFormFile ImagenFile { get; set; }

        [Display(Name = "Categoria" )]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

    }
}
