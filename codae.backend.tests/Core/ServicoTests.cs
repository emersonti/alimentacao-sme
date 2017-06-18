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

            servico.AdicionarComponente(1, "Arroz");
            servico.AdicionarComponente(2, "Feijão");

            Assert.Equal(2, servico.Composicao.Count());
        }

        [Fact]
        public void Adicionar_componentes_repetidos_nao_alteram_contagem()
        {
            var servico = CreateServico();

            servico.AdicionarComponente(1, "Arroz");
            servico.AdicionarComponente(1, "Arroz");

            Assert.Equal(1, servico.Composicao.Count());
        }

        private static Servico CreateServico()
        {
            return Servico.Create("Almoço");
        }
    }
}
