using System;
using codae.backend.core.Models;
using codae.backend.data.Contexts;
using Xunit;
using codae.backend.data.Repositories;
using System.Linq;

namespace codae.backend.tests.Repositories
{
    public class ServicoRepositoryTests
    {
        [Fact]
        public void Deve_Criar_servico_com_Dois_Pratos()
        {
            var context = ContextHelper.CreateContext();
            var servico = Servico.Create("Dejejum");
            var prato1 = Prato.Create("Leite");
            var prato2 = Prato.Create("Pão com manteiga");

            servico.AdicionarComponente(prato1.PratoId, prato1.Nome);
            servico.AdicionarComponente(prato2.PratoId, prato2.Nome);

            var pratoRepository = ContextHelper.CreatePratoRepository(context);
            var repository = ContextHelper.CreateServicoRepository(context);

            pratoRepository.Add(prato1);
            pratoRepository.Add(prato2);
            repository.Add(servico);

            repository.SaveChanges();

            var existing = repository.GetByKey(servico.ServicoId);
            Assert.Equal(2, existing.Composicao.Count());
        }
    }
}