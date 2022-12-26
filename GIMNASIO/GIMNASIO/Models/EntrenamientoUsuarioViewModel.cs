using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class EntrenamientoUsuarioViewModel
    {
        public Cliente cliente { get; set; }

        public List<EntrenamientoUsuario> ListaEntrenamiento { get; set; }

        public Entrenamiento Entrenamiento { get; set; }
    }
}
