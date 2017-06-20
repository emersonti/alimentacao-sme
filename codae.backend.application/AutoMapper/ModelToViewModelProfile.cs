using AutoMapper;
using codae.backend.application.ViewModels;
using codae.backend.core.Models;
using System.Collections.Generic;

namespace codae.backend.application.AutoMapper
{
    public class ModelToViewModelProfile: Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Regiao, RegiaoViewModel>();
            CreateMap<Servico, ServicoViewModel>()
                .ConvertUsing((src, dst, context) => new ServicoViewModel()
                {
                    ServicoId = src.ServicoId,
                    Nome = src.Nome,
                    Composicao = new ComposicaoServicoViewModel()
                    {
                        ServicoId = src.ServicoId,
                        Componentes = context.Mapper.Map<IEnumerable<ItemServicoViewModel>>(src.Composicao)
                    }
                });

            CreateMap<ItemServico, ItemServicoViewModel>();
            CreateMap<Prato, GrupoPratoViewModel>();
            CreateMap<Prato, PratoViewModel>();
        }
    }
}
