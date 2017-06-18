using codae.backend.data.Extensions;
using codae.backend.data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using codae.backend.core.Models;

namespace codae.backend.data.Contexts
{
    public class CODAEContext: DbContext
    {
        public CODAEContext(): base() { }

        public CODAEContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new AgrupamentoMapping());
            modelBuilder.AddConfiguration(new CardapioMapping());
            modelBuilder.AddConfiguration(new ItemCardapioMapping());
            modelBuilder.AddConfiguration(new ItemServicoMapping());
            modelBuilder.AddConfiguration(new PratoMapping());
            modelBuilder.AddConfiguration(new RegiaoMapping());
            modelBuilder.AddConfiguration(new ServicoMapping());
            modelBuilder.AddConfiguration(new TipoGestaoMapping());
            modelBuilder.AddConfiguration(new TipoUnidadeEscolarMapping());
            modelBuilder.AddConfiguration(new UnidadeEscolarMapping());

            base.OnModelCreating(modelBuilder);
        }

        public void EnsureSeed()
        {
            SeedAgrupamentos();
            SeedTipoGestao();
            SeedTipoUnidadeEscolar();

            this.SaveChanges();
        }

        private void SeedTipoUnidadeEscolar()
        {
            var values = Enum.GetValues(typeof(TipoUnidadeEscolarEnum));
            foreach (var value in values)
            {
                var name = Enum.GetName(typeof(TipoUnidadeEscolarEnum), value);
                this.Set<TipoUnidadeEscolar>().AddOrUpdate(TipoUnidadeEscolar.Create((TipoUnidadeEscolarEnum) value, name), t => t.TipoUnidadeEscolarId);
            }
        }

        private void SeedTipoGestao()
        {
            var values = Enum.GetValues(typeof(TipoGestaoEnum));
            foreach (var value in values)
            {
                var name = Enum.GetName(typeof(TipoGestaoEnum), value);
                this.Set<TipoGestao>().AddOrUpdate(TipoGestao.Create((TipoGestaoEnum) value, name), t => t.TipoGestaoId);
            }
        }

        private void SeedAgrupamentos()
        {            
            var values = Enum.GetValues(typeof(AgrupamentoEnum));
            foreach(var value in values)
            {
                
                var name = Enum.GetName(typeof(AgrupamentoEnum), value);
                this.Set<Agrupamento>().AddOrUpdate(Agrupamento.Create((AgrupamentoEnum) value, name), a=> a.AgrupamentoId);
            }
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder
                .UseSqlServer(config.GetConnectionString("DefaultConnection"), 
                opt => opt.EnableRetryOnFailure());            
        }*/
    }
}