using codae.backend.data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using codae.backend.application.Services;
using codae.backend.data.Repositories;
using AutoMapper;
using codae.backend.application.AutoMapper;

namespace codae.backend.ui
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add database
            services.AddDbContext<CODAEContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                opt => opt.EnableRetryOnFailure());
            });


            // Register Repositories
            services.AddTransient<IRegiaoRepository, RegiaoRepository>();
            services.AddTransient<IServicoRepository, ServicoRepository>();
            services.AddTransient<IPratoRepository, PratoRepository>();
            services.AddTransient<ICardapioRepository, CardapioRepository>();

            // Register Application Services
            services.AddTransient<IRegiaoService, RegiaoService>();
            services.AddTransient<IServicoService, ServicoService>();
            services.AddTransient<IPratoService, PratoService>();                            

            // Add AutoMapper mappings
            services.AddSingleton<IMapper>(c => new Mapper(AutoMapperConfiguration.RegisterMappings()));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}