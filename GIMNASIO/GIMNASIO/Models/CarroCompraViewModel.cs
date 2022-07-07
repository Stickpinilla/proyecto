using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class CarroCompraViewModel
    {
        public List<CarroItem> carroItems { get; set; }

        public double TotalCarro { get; set; }
    }
}
