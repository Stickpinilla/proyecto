using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GIMNASIO.Models
{
    public class MaquinariaViewModel
    {
        public List<Maquinaria> ListaMaquinaria { get; set; }

        public int CantidadPagina { get; set; }

        public int Pagina { get; set; }

        [Display(Name = "EstadoMaquinaria")]
        public int EstadoId { get; set; }
        public EstadoMaquinaria EstadoMaquinaria { get; set; }

        [Display(Name = "TipoMaquinaria")]
        public int TipoId { get; set; }
        public TipoMaquinaria TipoMaquinaria { get; set; }

    }
}
