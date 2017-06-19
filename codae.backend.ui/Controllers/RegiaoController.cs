using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using codae.backend.application.Services;

namespace codae.backend.ui.Controllers
{
    public class RegiaoController : Controller
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}