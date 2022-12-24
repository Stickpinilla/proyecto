using System;
using System.Collections.Generic;

namespace GIMNASIO.Models
{
    public class AvanceViewModel
    {
        public List<AvanceCliente> ListaAvance { get; set; }
        public Double AvanceCliente_Peso { get; set; }

        public Double AvanceCliente_Altura { get; set; }

        public float AvanceCliente_IMC { get; set; }
        
        public DateTime AvanceCliente_Fecha { get; set; }
        public string AvanceCliente_Situacion { get; set; }
        public string Id { get; set; }

    }
}
