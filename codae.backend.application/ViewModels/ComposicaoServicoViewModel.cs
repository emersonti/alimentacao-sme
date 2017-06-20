using System.Collections;
using System.Collections.Generic;

namespace codae.backend.application.ViewModels
{
    public class ComposicaoServicoViewModel
    {
        public int ServicoId { get; set; }
        public IEnumerable<ItemServicoViewModel> Componentes { get; set; }
        public int PlanoId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<GrupoPratoViewModel> GruposPrato { get; set; }
    }
}