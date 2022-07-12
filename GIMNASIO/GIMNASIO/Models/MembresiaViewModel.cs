using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class MembresiaViewModel
    {
        public List<Membresia> ListaMembresias { get; set; }

        [Display(Name = "Metodo de Pago")]
        public int MetodoPagoMembresiaId { get; set; }
        public MetodoPagoMembresia MetodoPagoMembresia { get; set; }

        [Display(Name = "Estado de Membresia")]
        public int EstadoMembresiaId { get; set; }
        public EstadoMembresia EstadoMembresia { get; set; }

        [Display(Name = "Tipo de Membresia")]
        public int TipoMembresiaId { get; set; }
        public TipoMembresia TipoMembresia { get; set; }

    }
}
