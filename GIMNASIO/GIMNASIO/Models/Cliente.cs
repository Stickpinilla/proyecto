using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class Cliente : IdentityUser
    {
        public string Rut { get; set; }

        public string Nombres { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Correo { get; set; }

        public DateTime fecha { get; set; }
    }
}
