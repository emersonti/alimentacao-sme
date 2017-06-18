using codae.backend.core.Models;
using codae.backend.data.Contexts;
using codae.backend.data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace codae.backend.tests.Repositories
{    
    public class CardapioRepositoryTests
    {
        [Fact]
        public void Deve_Inicializar_um_Cardapio()
        {
            var context = ContextHelper.CreateContext();
            var cardapioRepository = ContextHelper.CreateCardapioRepository(context);
            Cardapio cardapio = CreateCardapio();

            cardapioRepository.Add(cardapio);
            cardapioRepository.SaveChanges();

            var existing = cardapioRepository.GetByKey(cardapio.CardapioId);

            Assert.Equal(0, existing.ItensCardapio.Count());
        }

        private static Cardapio CreateCardapio()
        {
            return Cardapio.Create(AgrupamentoEnum.Agrupamento1, TipoGestaoEnum.Mista,
                new DateTime(2017, 7, 1), new DateTime(2017, 7, 7));
        }

        [Fact]
        public void Deve_Criar_Cardapio_com_dois_itens()
        {
            var context = ContextHelper.CreateContext();
            var cardapioRepository = ContextHelper.CreateCardapioRepository(context);
            var servicoRepository = ContextHelper.CreateServicoRepository(context);
            var pratoRepository = ContextHelper.CreatePratoRepository(context);

            var prato = Prato.Create("Arroz");
            var servico = Servico.Create("Almoço");

            pratoRepository.Add(prato);
            servicoRepository.Add(servico);

            servicoRepository.SaveChanges();

            var cardapio = CreateCardapio();
            cardapio.AdicionarItem(servico.ServicoId, prato.PratoId, 
                new DateTime(2017, 7, 1));

            cardapioRepository.Add(cardapio);
            cardapioRepository.SaveChanges();

            var existing = cardapioRepository.GetByKey(cardapio.CardapioId);

            Assert.Equal(1, cardapio.ItensCardapio.Count());
        }
    }
}