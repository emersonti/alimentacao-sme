using codae.backend.data.Extensions;
using codae.backend.data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Contexts
{
    public class CODAEContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new AgrupamentoMapping());

            modelBuilder.AddConfiguration(new AgrupamentoMapping());
            modelBuilder.AddConfiguration(new PratoMapping());
            modelBuilder.AddConfiguration(new RegiaoMapping());
            modelBuilder.AddConfiguration(new TipoGestaoMapping());
            modelBuilder.AddConfiguration(new TipoUnidadeEscolarMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
