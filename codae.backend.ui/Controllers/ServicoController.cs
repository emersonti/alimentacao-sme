using codae.backend.application.Services;
using codae.backend.application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace codae.backend.ui.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoService _servicoService;        

        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;            
        }

        [HttpGet]
        public IActionResult Index() => View(_servicoService.GetAll());

        [HttpGet]
        public IActionResult Create() => View(new ServicoViewModel());

        [HttpPost]
        public IActionResult Create(ServicoViewModel servicoVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newId = _servicoService.CreateServico(servicoVM);
                    return RedirectToAction("Edit", new { id = newId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }            
            return View(servicoVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var servicoVM = _servicoService.GetByKey(id);            
            if (servicoVM == null)
                return NotFound();            
            return View(servicoVM);
        }

        [HttpPost]
        public IActionResult Edit(ServicoViewModel servicoVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoService.UpdateServico(servicoVM);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);                    
                }
            }            
            return View(servicoVM);
        }

        [HttpPost]
        public IActionResult CreateItem(ComposicaoServicoViewModel composicaoServicoVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _servicoService.CreateItemServico(composicaoServicoVM.ServicoId,
                        composicaoServicoVM.PlanoId, composicaoServicoVM.Nome);
                    composicaoServicoVM.Nome = "";
                    composicaoServicoVM.Componentes = _servicoService.GetItensServico(composicaoServicoVM.ServicoId);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return ViewComponent("ComposicaoServico", composicaoServicoVM);
        }
    }
}