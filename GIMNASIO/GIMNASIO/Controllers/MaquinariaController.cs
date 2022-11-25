using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyAdmin")]
    public class MaquinariaController : Controller
    {
        private readonly AppDbContext _context;

        public MaquinariaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaMaquinaria()
        {
            return View();
        }
    }
}
