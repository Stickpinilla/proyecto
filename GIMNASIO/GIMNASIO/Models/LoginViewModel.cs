using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email es Obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Contraseña es Obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
    }
}
