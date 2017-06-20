using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using codae.backend.application.Services;
using codae.backend.application.ViewModels;

namespace codae.backend.ui.Controllers
{
    public class PratoController : Controller
    {
        private readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }

        public async Task<IActionResult> Index() => View(await _pratoService.GetAllAsync());

        [HttpGet]
        public IActionResult Create() => View(new GrupoPratoViewModel());

        [HttpPost]
        public IActionResult Create(GrupoPratoViewModel grupoPratoVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newId = _pratoService.CreateGrupoPrato(grupoPratoVM);
                    return RedirectToAction("Edit", new { id = newId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(grupoPratoVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var grupoPratoVM = _pratoService.GetByKey(id);
            if (grupoPratoVM == null)
                return NotFound();
            return View(grupoPratoVM);
        }

        [HttpPost]
        public IActionResult Edit(GrupoPratoViewModel grupoPratoVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _pratoService.UpdateGrupoPrato(grupoPratoVM);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);                    
                }
            }
            return View(grupoPratoVM);
        }
    }
}