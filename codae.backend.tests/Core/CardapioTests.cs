using codae.backend.core.Models;
using System;
using System.Linq;
using Xunit;

namespace codae.backend.tests.Core
{
    public class CardapioTests
    {
        [Fact]
        public void Deve_criar_cardapio_com_um_servico_e_dois_pratos()
        {
            Cardapio cardapio = CreateCardapio();

            cardapio.AdicionarItem(1, 1, DateTime.Today);
            cardapio.AdicionarItem(1, 2, DateTime.Today);

            Assert.Equal(2, cardapio.ItensCardapio.Count());
        }

        [Fact]
        public void Adicionar_itens_repetidos_nao_alteram_contagem()
        {
            Cardapio cardapio = CreateCardapio();

            cardapio.AdicionarItem(1, 1, DateTime.Today);
            cardapio.AdicionarItem(1, 1, DateTime.Today);

            Assert.Equal(1, cardapio.ItensCardapio.Count());
        }

        private static Cardapio CreateCardapio()
        {
            return Cardapio.Create(AgrupamentoEnum.Agrupamento1,
                TipoGestaoEnum.Terceirzada, DateTime.Now,
                DateTime.Now.AddDays(30));
        }
    }
}