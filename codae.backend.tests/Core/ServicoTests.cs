using codae.backend.core.Models;
using System.Linq;
using Xunit;

namespace codae.backend.tests.Core
{
    public class ServicoTests
    {
        [Fact]
        public void Deve_criar_servico_com_dois_componentes()
        {
            var servico = CreateServico();
            var prato1 = Prato.Create("Aroz");
            var prato2 = Prato.Create("Feijão");

            servico.AdicionarComponente(prato1);
            servico.AdicionarComponente(prato2);

            Assert.Equal(2, servico.Composicao.Count());
        }

        [Fact]
        public void Adicionar_componentes_repetidos_nao_alteram_contagem()
        {
            var servico = CreateServico();
            var prato = Prato.Create("Arroz");

            servico.AdicionarComponente(prato);
            servico.AdicionarComponente(prato);

            Assert.Equal(1, servico.Composicao.Count());
        }

        private static Servico CreateServico()
        {
            return Servico.Create("Almoço");
        }
    }
}
