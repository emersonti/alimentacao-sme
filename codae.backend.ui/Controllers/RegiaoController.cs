using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using codae.backend.application.Services;
using codae.backend.application.ViewModels;

namespace codae.backend.ui.Controllers
{
    public class RegiaoController : Controller
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        public IActionResult Index() => View(_regiaoService.GetAll());

        [HttpGet]
        public IActionResult Create() => View(new RegiaoViewModel());

        [HttpPost]
        public IActionResult Create(RegiaoViewModel regiaoVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newId = _regiaoService.CreateRegiao(regiaoVM);
                    return RedirectToAction("Edit", new { id = newId });
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(regiaoVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var regiaoVM = _regiaoService.GetByKey(id);
            if (regiaoVM == null)
                return NotFound();

            return View(regiaoVM);
        }

        [HttpPost]
        public IActionResult  Edit(RegiaoViewModel regiaoVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _regiaoService.UpdateRegiao(regiaoVM);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(regiaoVM);
        }
    }
}