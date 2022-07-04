using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIMNASIO.Controllers
{
    [Authorize(Policy = "PolicyAdmin")]
    public class CategoriaController : Controller
    {

        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }


        //listar Categorias
        public IActionResult ListarCategorias()
        {
            var listadocat = _context.tblCategorias.ToList();
            return View(listadocat);
        }

        //llamar a la vista de crear
        [HttpGet]
        public IActionResult CrearCategorias()
        {
            return View();
        }

        //Crear la categoria
        [HttpPost]
        public async Task<IActionResult> CrearCategorias(Categoria C)
        {
            if (ModelState.IsValid)
            {
                var existe = _context.tblCategorias.Where(c => c.Nombre.Equals(C.Nombre)).FirstOrDefault();
                if (existe == null)
                {
                    _context.Add(C);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Categoria Agregada Exitosamente!";
                    return RedirectToAction(nameof(ListarCategorias));
                }
                else
                {
                    ModelState.AddModelError("", "La Categoria ya existe en el sistema");
                }
            }
            return View(C);
        }


        //Llamar a la vista editar
        [HttpGet]
        public IActionResult EditarCategorias(int CategoriaId)
        {
            var C = _context.tblCategorias.Where(c => c.CategoriaId.Equals(CategoriaId)).FirstOrDefault();
            return View(C);

        }

        //Editar categoria
        [HttpPost]
        public async Task<IActionResult> EditarCategorias(Categoria C)
        {
            if (ModelState.IsValid)
            {
                var EditCat = _context.tblCategorias.Where(c => c.CategoriaId.Equals(C.CategoriaId)).FirstOrDefault();

                EditCat.Nombre = C.Nombre;
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Categoria Modificada exitosamente!";
                return RedirectToAction(nameof(ListarCategorias));
            }
            else
            {
                return View(C);
            }
        }


        //Llamar a la view de eliminar
        [HttpGet]
        public IActionResult EliminarCategoria(int CategoriaId)
        {
            var C = _context.tblCategorias.Where(c => c.CategoriaId.Equals(CategoriaId)).FirstOrDefault();
            return View(C);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCategoria(Categoria C)
        {
            var catEliminar = _context.tblCategorias.Where(c => c.CategoriaId == C.CategoriaId).FirstOrDefault();
            _context.Entry(catEliminar).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Categoria Eliminada Exitosamente!";
            return RedirectToAction(nameof(ListarCategorias));
        }






    }
}
