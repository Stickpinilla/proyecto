using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Membresia
    {
        public int MembresiaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaComienzo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaTermino { get; set; }

        public EstadoMembresia EstadoMembresia { get; set; }
        public TipoMembresia TipoMembresia { get; set; }
        public MetodoPagoMembresia MetodoPagoMembresia { get; set; }
        public Cliente Cliente { get; set; }
    }
}
