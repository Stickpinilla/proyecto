using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GIMNASIO.Models
{
    public class MaquinariaMantencionViewModel
    {
        public Maquinaria Maquinaria { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MantencionFechaIngreso { get; set; }

        public string MantencionDescripcion { get; set; }

        public int EstadoMantencionId { get; set; }

        public int MaquinariaId { get; set; }

        public int UserId { get; set; }

    }
}

