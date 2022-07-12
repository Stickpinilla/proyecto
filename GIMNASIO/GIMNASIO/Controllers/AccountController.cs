using GIMNASIO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<Cliente> userManager, SignInManager<Cliente> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        //llamar a login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Lvm)
        {

            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(Lvm.Correo);
                if (User != null)
                {
                    var con = await _userManager.FindByEmailAsync(Lvm.Pass);
                    if (con == null)
                    {
                        var resultado = await _signInManager.PasswordSignInAsync(User, Lvm.Pass, false, false);
                        if (resultado.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Contraseña Incorrecta");
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Email NO encotrado");
            }
            return View(Lvm);
        }

        //cerrar la sesion
        public async Task<IActionResult> CerrarSesion()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //llamar al registro
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel Rvm)
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
                    return RedirectToAction(nameof(Login));
                }

            }
            return View();
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
                    return RedirectToAction(nameof(Login));
                }

            }
            return View();
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
                    return RedirectToAction(nameof(Login));
                }

            }
            return View();
        }

        //empieza mis pedidos
        public async Task<IActionResult> MisPedidos()
        {
            var Cliente = await _userManager.GetUserAsync(HttpContext.User);
            MisPedidosViewModel Mvm = new MisPedidosViewModel
            {
                cliente = Cliente,
                ListaPedidos = _context.tblPedido
                .Where(P => P.Cliente.Id == Cliente.Id).ToList()
            };
            return View(Mvm);
        }

    }
}
