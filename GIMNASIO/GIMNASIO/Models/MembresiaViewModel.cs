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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaComienzo { get; set; }

        public int EstadoMembresiaId { get; set; }
        public EstadoMembresia EstadoMembresia { get; set; }

        public int TipoMembresiaId { get; set; }
        public TipoMembresia TipoMembresia { get; set; }

        public int MetodoPagoMembresiaId { get; set; }
        public MetodoPagoMembresia MetodoPagoMembresia { get; set; }

        public string Id { get; set; }
        public Cliente Cliente { get; set; }

    }
}
