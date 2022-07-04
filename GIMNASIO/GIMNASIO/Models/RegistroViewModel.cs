using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Rut es Obligatorio")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "Nombre es Obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellido Paterno es Obligatorio")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "Apellido Materno es Obligatorio")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }

        [Required(ErrorMessage = "Contraseña es Requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Correo es Obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Telefono es Obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Direccion es Obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ciudad es Obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Fecha Nacimiento es Obligatorio")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime fecha { get; set; }
    }

}
