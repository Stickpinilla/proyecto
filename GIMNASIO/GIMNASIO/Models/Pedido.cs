using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PedidoFecha { get; set; }

        public Cliente Cliente { get; set; }

        public int PedidoTotal { get; set; }

        public MetodoPago MetodoPago { get; set; }

        [Display(Name = "Estado")]
        public int PedidoEstadoId { get; set; }
        public PedidoEstado PedidoEstado { get; set; }

    }
}
