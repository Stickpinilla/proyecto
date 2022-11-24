using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Mantencion
    {
        public int MantencionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MantencionFechaIngreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MantencionFechaFin { get; set; }

        public string MantencionProcedimiento { get; set; }

        public int MantencionEstadoId { get; set; }

        public EstadoMantencion EstadoMantencion { get; set; }
        public int MantencionMaquinariaId { get; set; }
        public Maquinaria Maquinaria { get; set; }

        public int MantencionEncargadoId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
