using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class AvanceCliente
    {
        [Key]
        public int AvanceClienteId { get; set; }

        public Double AvanceCliente_Peso { get; set; }

        public Double AvanceCliente_Altura { get; set; }

        public float AvanceCliente_IMC { get; set; }
         public DateTime AvanceCliente_Fecha { get; set; }
        public string AvanceCliente_Situacion { get; set; }

        public Cliente Cliente { get; set; }


    }
}

