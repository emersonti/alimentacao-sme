using codae.backend.core.Models;
using codae.backend.data.Contexts;
using codae.backend.data.Repositories;
using System;
using Xunit;

namespace codae.backend.tests.Repositories
{
    public class RegiaoRepositoryTests
    {
        [Fact]
        public void Deve_Criar_Nova_Regiao()
        {
            var regiao = Regiao.Create(AgrupamentoEnum.Agrupamento1, Guid.NewGuid().ToString(),
                "Dirigente Teste", "email@algo.com", "(11) 98998-2198");
            var repository = CreateRepository();

            repository.Add(regiao);
            var result = repository.SaveChanges();

            Assert.Equal(1, result);
        }

        private RegiaoRepository CreateRepository()
        {            
            return new RegiaoRepository(ContextHelper.Context);
        }
    }
}
