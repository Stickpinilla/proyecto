using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GIMNASIO.Models
{
    public class Maquinaria
    {
        public int MaquinariaId { get; set; }

        [Display(Name = "Nombre de máquina ")]
        public string MaquinariaNombre { get; set; }

        [Display(Name = "Número de serie de la máquina")]
        public string MaquinariaNumeroSerie { get; set; }


        [Display(Name = "Estado de máquina")]
        public int EstadoMaquinariaId { get; set; }

        public EstadoMaquinaria EstadoMaquinaria { get; set; }


        [Display(Name = "Tipo de máquina")]

        public int TipoMaquinariaId { get; set; }

        public TipoMaquinaria TipoMaquinaria { get; set; }
    }
}
