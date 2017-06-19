using AutoMapper;
using codae.backend.application.ViewModels;
using codae.backend.core.Models;

namespace codae.backend.application.AutoMapper
{
    public class ModelToViewModelProfile: Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Regiao, RegiaoViewModel>();
            CreateMap<Servico, ServicoViewModel>();
            CreateMap<ItemServico, ItemServicoViewModel>();
            CreateMap<Prato, GrupoPratoViewModel>();
            CreateMap<Prato, PratoViewModel>();
        }
    }
}
