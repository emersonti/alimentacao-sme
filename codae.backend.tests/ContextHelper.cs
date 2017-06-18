using codae.backend.data.Contexts;
using codae.backend.data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.tests
{
    public static class ContextHelper
    {
        public static CODAEContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase();

            var context = new CODAEContext(builder.Options);

            context.Database.EnsureCreated();
            context.EnsureSeed();

            return context;
        }

        public static CardapioRepository CreateCardapioRepository(CODAEContext context) =>
            new CardapioRepository(context);

        public static PratoRepository CreatePratoRepository(CODAEContext context) =>
            new PratoRepository(context);

        public static  ServicoRepository CreateServicoRepository(CODAEContext context) =>
            new ServicoRepository(context);

        public static RegiaoRepository CreateRegiaoRepository(CODAEContext context) =>
            new RegiaoRepository(context);

        public static UnidadeEscolarRepository CreateUnidadeEscolarRepository(CODAEContext context) =>
            new UnidadeEscolarRepository(context);
    }
}