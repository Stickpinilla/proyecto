using GIMNASIO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;

        public ClienteController(UserManager<Cliente> userManager, SignInManager<Cliente> signInManager,
            AppDbContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ListarCliente()
        {
            var clientelista = _context.Users.ToList();
            return View(clientelista);
        }

        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente(RegistroViewModel Rvm)
        {
            if (ModelState.IsValid)
            {
                var User = new Cliente()
                {
                    Rut = Rvm.Rut,
                    Nombres = Rvm.Nombres,
                    ApellidoP = Rvm.ApellidoP,
                    ApellidoM = Rvm.ApellidoM,
                    Correo = Rvm.Correo,
                    Email = Rvm.Correo,
                    Telefono = Rvm.Telefono,
                    Direccion = Rvm.Direccion,
                    Ciudad = Rvm.Ciudad,
                    fecha = Rvm.fecha.Date,
                    UserName = Rvm.Correo,
                    Tipo = "Cliente"
                };
                var resultado = await _userManager.CreateAsync(User, Rvm.Pass);
                if (resultado.Succeeded)
                {
                    //TODOS LOS USUARIOS REGISTRADOS SE INGRESEN CON ESE CLAIM
                    await _userManager.AddClaimAsync(User, new System.Security.Claims.Claim("Cliente", "10"));
                    return RedirectToAction(nameof(ListarCliente));
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult ModificarCliente()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EliminarCliente(Cliente C)
        {
            var ClienteBorrar = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            _context.Entry(ClienteBorrar).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarCliente));
        }
    }
}
