using codae.backend.application.ViewModels;
using Xunit;

namespace codae.backend.tests.Services
{
    public class ServicoServiceTests
    {
        [Fact]
        public void Deve_Cirar_Servico_com_dois_componentes()
        {
            var context = ContextHelper.CreateContext();
            var service = ContextHelper.CreateServicoService(context);

            var servicoVM = new ServicoViewModel()
            {
                Nome = "Almoço"
            };

            var id = service.CreateServico(servicoVM);

            Assert.NotEqual(0, id);
        }
    }
}
