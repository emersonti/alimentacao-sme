using codae.backend.application.ViewModels;
using Xunit;

namespace codae.backend.tests.Services
{
    public class RegiaoServiceTests
    {
        [Fact]
        public void Deve_Cirar_Servico()
        {
            var context = ContextHelper.CreateContext();
            var service = ContextHelper.CreateRegiaoService(context);

            var regiao = new RegiaoViewModel()
            {
                Nome = "Ipiranga",
                AgrupamentoId = Agrupamentos.Agrupamento1
            };

            var id = service.CreateRegiao(regiao);

            Assert.NotEqual(0, id);
        }
    }
}