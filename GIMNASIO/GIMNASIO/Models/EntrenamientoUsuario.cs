using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class EntrenamientoUsuario
    {
        public int EntrenamientoUsuarioId { get; set; }

        public Cliente Cliente { get; set; }

        public int EntrenamientoId { get; set; }
        public Entrenamiento entrenamiento { get; set; }

    }
}
