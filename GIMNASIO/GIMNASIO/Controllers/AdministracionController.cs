using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class AdministracionController : Controller
    {
        public IActionResult Administracion()
        {
            return View();
        }

        public IActionResult RegistroEntrenador()
        {
            return View();
        }
    }
}
