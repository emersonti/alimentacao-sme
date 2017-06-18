using codae.backend.core.Models;
using codae.backend.data.Repositories;
using Xunit;

namespace codae.backend.tests.Repositories
{
    public class PratoRepositoryTests
    {
        [Fact]
        public void Deve_Cadastrar_Grupo_com_um_Prato()
        {
            var grupo = Prato.Create("Arroz");
            var prato = Prato.Create(grupo, "Arroz com Cenoura");

            var repository = ContextHelper.CreatePratoRepository(ContextHelper.CreateContext());

            repository.Add(grupo);
            repository.Add(prato);

            int result = repository.SaveChanges();

            var existent = repository.GetByKey(prato.PratoId);

            Assert.Equal(grupo.PratoId, existent.GrupoPratoId);
        }
    }
}