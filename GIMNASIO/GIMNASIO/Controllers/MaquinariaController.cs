﻿using GIMNASIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult ListaMaquinaria(int EstadoId)
        {
            int estado = 1;
            if (EstadoId != estado) {
                estado = EstadoId;
            }

            ViewData["TipoId"] = new SelectList(_context.tblTipoMaquinaria.ToList(), "TipoMaquinariaId", "TipoMaquinariaNombre");
            ViewData["EstadoId"] = new SelectList(_context.tblEstadoMaquinaria.ToList(), "EstadoMaquinariaId", "EstadoMaquinariaNombre");
            MaquinariaViewModel viewModel = new MaquinariaViewModel();
            viewModel.ListaMaquinaria = _context.tblMaquinaria
                .Where(m => m.EstadoMaquinariaId == estado)
                .Include(m => m.TipoMaquinaria)
                .Include(m => m.EstadoMaquinaria)
                .ToList();
            TempData["NextPage"] = viewModel.Pagina + 1;
            TempData["PreviusPage"] = viewModel.Pagina - 1;
            TempData["Estado"] = estado;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CrearMaquinaria()
        {
            ViewData["EstadoMaquinariaId"] = new SelectList(_context.tblEstadoMaquinaria.ToList(), "EstadoMaquinariaId", "EstadoMaquinariaNombre");
            ViewData["TipoMaquinariaId"] = new SelectList(_context.tblTipoMaquinaria.ToList(), "TipoMaquinariaId", "TipoMaquinariaNombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearMaquinaria(Maquinaria M)
        {
            if (ModelState.IsValid)
            {
                _context.Add(M);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaria Agregado Exitosamente!";
                return RedirectToAction("ListaMaquinaria", new { EstadoId = 1 });
            }
            return View(M);
        }

        //Inhabilitar maquinaria por Id
        [HttpGet]
        public async Task<IActionResult> InhabilitarMaquinaria(int MaquinariaId)
        {
            var MaquinariaInhabilitada = _context.tblMaquinaria.Where(m => m.MaquinariaId == MaquinariaId).FirstOrDefault();
            MaquinariaInhabilitada.EstadoMaquinariaId = 2;//estado: inhabilitado
            await _context.SaveChangesAsync();
            return RedirectToAction("ListaMaquinaria", new { EstadoId = 1 });
        }

        [HttpGet]
        public IActionResult ModificarMaquinaria(int MaquinariaId)
        {
            ViewData["EstadoMaquinariaId"] = new SelectList(_context.tblEstadoMaquinaria.ToList(), "EstadoMaquinariaId", "EstadoMaquinariaNombre");
            ViewData["TipoMaquinariaId"] = new SelectList(_context.tblTipoMaquinaria.ToList(), "TipoMaquinariaId", "TipoMaquinariaNombre");
            var Maquinaria = _context.tblMaquinaria.Where(m => m.MaquinariaId == MaquinariaId).FirstOrDefault();
            return View(Maquinaria);
        }

        //Editar maquinaria
        [HttpPost]
        public async Task<IActionResult> ModificarMaquinaria(Maquinaria M)
        {
            if (ModelState.IsValid)
            {
                var MaquinariaEditar = _context.tblMaquinaria.Where(m => m.MaquinariaId == M.MaquinariaId).FirstOrDefault();

                MaquinariaEditar.MaquinariaNombre = M.MaquinariaNombre;
                MaquinariaEditar.MaquinariaNumeroSerie = M.MaquinariaNumeroSerie;
                MaquinariaEditar.TipoMaquinariaId = M.TipoMaquinariaId;
                MaquinariaEditar.EstadoMaquinariaId = M.EstadoMaquinariaId;

                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Maquinaría Modificada exitosamente!";
                return RedirectToAction("ListaMaquinaria", new { EstadoId = M.EstadoMaquinariaId });
            }
            else
            {
                return View(M);
            }
        }


    }
}
