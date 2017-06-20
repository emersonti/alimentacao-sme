using codae.backend.application.Services;
using codae.backend.application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace codae.backend.ui.ViewComponents
{
    [ViewComponent(Name ="ComposicaoServico")]
    public class ComposicaoServicoViewComponent: ViewComponent
    {
        private readonly IPratoService _pratoService;

        public ComposicaoServicoViewComponent(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComposicaoServicoViewModel composicaoServicoVM)
        {
            composicaoServicoVM.GruposPrato = await _pratoService.GetAllAsync();
            return View(composicaoServicoVM);
        }
    }
}
