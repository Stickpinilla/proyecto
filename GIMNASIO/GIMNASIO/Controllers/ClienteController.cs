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
            var clientelista = _context.Users.Where(t => t.Tipo == "Cliente").ToList();
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

        public IActionResult Producto(int ProductoId)
        {

            return View(_context.tblProductos.Where(p => p.ProductoId.Equals(ProductoId))
                .Include(c => c.Categoria)
                .Include(e => e.Estado)
                .ToList());
        }



        public IActionResult ListarEntrenadores()
        {
            var entrenadorlista = _context.Users.Where(t => t.Tipo == "Entrenador").ToList();
            return View(entrenadorlista);
        }


        //llamar al registro entrenador
        [HttpGet]
        public IActionResult RegistroEntrenador()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistroEntrenador(RegistroViewModel Rvm)
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
                    Tipo = "Entrenador"
                };
                var resultado = await _userManager.CreateAsync(User, Rvm.Pass);
                if (resultado.Succeeded)
                {
                    //TODOS LOS USUARIOS REGISTRADOS SE INGRESEN CON ESE CLAIM
                    await _userManager.AddClaimAsync(User, new System.Security.Claims.Claim("Entrenador", "10"));
                    return RedirectToAction(nameof(ListarEntrenadores));
                }

            }
            return View();
        }


        public async Task<IActionResult> EliminarEntrenador(Cliente C)
        {
            var ClienteBorrar = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            _context.Entry(ClienteBorrar).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarEntrenadores));
        }



        public IActionResult ListarAdmin()
        {
            var adminlista = _context.Users.Where(t => t.Tipo == "Admin").ToList();
            return View(adminlista);
        }


        //llamar al registro admin
        [HttpGet]
        public IActionResult RegistroAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistroAdmin(RegistroViewModel Rvm)
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
                    Tipo = "Admin"
                };
                var resultado = await _userManager.CreateAsync(User, Rvm.Pass);
                if (resultado.Succeeded)
                {
                    //TODOS LOS USUARIOS REGISTRADOS SE INGRESEN CON ESE CLAIM
                    await _userManager.AddClaimAsync(User, new System.Security.Claims.Claim("Admin", "10"));
                    return RedirectToAction(nameof(ListarAdmin));
                }

            }
            return View();
        }



        public async Task<IActionResult> EliminarAdmin(Cliente C)
        {
            var ClienteBorrar = _context.Users.Where(c => c.Id == C.Id).FirstOrDefault();
            _context.Entry(ClienteBorrar).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarAdmin));
        }


    }
}
