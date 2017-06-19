using AutoMapper;
using codae.backend.application.ViewModels;
using codae.backend.core.Models;

namespace codae.backend.application.AutoMapper
{
    public class ViewModelToModel: Profile
    {
        public ViewModelToModel()
        {
            CreateMap<RegiaoViewModel, Regiao>();
            CreateMap<ServicoViewModel, Servico>();
            CreateMap<ItemServicoViewModel, ItemServico>();
            CreateMap<GrupoPratoViewModel, Prato>();
            CreateMap<PratoViewModel, Prato>();
        }
    }
}
