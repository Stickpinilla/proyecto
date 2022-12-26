using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class EntrenamientoViewModel
    {
        public List<Entrenamiento> ListarEntrenamiento { get; set; }

        [Display(Name = "Zona de Entrenamiento")]
        public int EntrenamientoZonaId { get; set; }
        public EntrenamientoZona entrenamientozona { get; set; }

        [Display(Name = "Estado de entrenamiento")]
        public int EntrenamientoEstadoId { get; set; }
        public EntrenamientoEstado entrenamientoestado { get; set; }

        [Display(Name = "Categoria")]
        public int EntrenamientoCategoriaId { get; set; }
        public EntrenamientoCategoria entrenamientocategoria { get; set; }

        public Cliente Cliente { get; set; }

    }
}
