using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class CarroCompraViewModel
    {
        public List<CarroItem> carroItems { get; set; }

        public double TotalCarro { get; set; }

        [Display(Name = "Metodo de Pago")]
        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
    }
}
