using GIMNASIO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class ClienteController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public ClienteController(AppDbContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
        }
        public IActionResult ListarCliente()
        {
            var clientelista = _context.Users.ToList();
            return View(clientelista);
        }
    }
}
