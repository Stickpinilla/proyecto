using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyAdmin")]
    public class AvanceController : Controller
    {
        private readonly AppDbContext _context;

        public AvanceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaAvancePorCliente(Cliente C)
        {
            AvanceViewModel avm = new AvanceViewModel();
            var Cliente = _context.Users
                   .Where(c => c.Id == C.Id).FirstOrDefault();
            avm.ListaAvance = _context.tblAvanceCliente
                    .Where(a => a.Cliente == C).ToList();
            avm.Id = Cliente.Id;
            return View(avm);
        }

        public IActionResult AgregarAvance(string ClienteId)
        {
            var cliente = _context.Users.Where(c => c.Id == ClienteId).FirstOrDefault();

            AvanceViewModel avm = new AvanceViewModel
            {
                Id = cliente.Id
            };

            return View(avm);
        }

        [HttpPost]
        public IActionResult AgregarAvance(AvanceViewModel avm)
        {
            if (ModelState.IsValid)
            {
                var Cliente = _context.Users.Where(u => u.Id == avm.Id).FirstOrDefault();

                var Imc = avm.AvanceCliente_Peso / (avm.AvanceCliente_Altura * avm.AvanceCliente_Altura);

                
                switch (Imc)
                {
                    case var n when n < 18.5:
                        avm.AvanceCliente_Situacion = "Insuficiencia Ponderada";
                        break;
                    case var n when n >= 18.5 && n < 25:
                        avm.AvanceCliente_Situacion = "Intervalo normal";
                        break;
                    case var n when n >= 25 && n < 30:
                        avm.AvanceCliente_Situacion = "Sobrepeso";
                        break;
                    case var n when n >= 30 && n < 35:
                        avm.AvanceCliente_Situacion = "Obesidad 1";
                        break;
                    case var n when n >= 35 && n < 40:
                        avm.AvanceCliente_Situacion = "Obesidad 2";
                        break;
                    case var n when n >= 40:
                        avm.AvanceCliente_Situacion = "Obesidad 3";
                        break;
                }

                AvanceCliente avance = new AvanceCliente();
                avance.AvanceCliente_Altura = avm.AvanceCliente_Altura;
                avance.AvanceCliente_Peso = avm.AvanceCliente_Peso;
                avance.AvanceCliente_Fecha = avm.AvanceCliente_Fecha;
                avance.AvanceCliente_Situacion = avm.AvanceCliente_Situacion;
                avance.AvanceCliente_IMC = ((float)Imc);
                avance.Cliente = Cliente;
                _context.Add(avance);
                _context.SaveChanges();

                return RedirectToAction("ListaAvancePorCliente", Cliente);
            }

            return View(avm.Id);
            
        }
    }
}
