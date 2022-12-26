using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Entrenamiento
    {
        public int EntrenamientoId { get; set; }

        public int EntrenamientoCupoTotal { get; set; }

        public int EntrenamientoCupoDisponible { get; set; }

        public string EntrenamientoDescripcion { get; set; }

        public int EntrenamientoZonaId { get; set; }
        public EntrenamientoZona entrenamientozona { get; set; }

        public int EntrenamientoEstadoId { get; set; }
        public EntrenamientoEstado entrenamientoestado { get; set; }

        public int EntrenamientoCategoriaId { get; set; }
        public EntrenamientoCategoria entrenamientocategoria { get; set; }

        public Cliente Cliente { get; set; }

    }
}
