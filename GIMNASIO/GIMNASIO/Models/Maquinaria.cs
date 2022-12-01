using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Maquinaria
    {
        public int MaquinariaId { get; set; }
        public string MaquinariaNombre { get; set; }
        public string MaquinariaNumeroSerie { get; set; }

        public int EstadoMaquinariaId { get; set; }
        public EstadoMaquinaria EstadoMaquinaria { get; set; }

        public int TipoMaquinariaId { get; set; }
        public TipoMaquinaria TipoMaquinaria { get; set; }
    }
}
