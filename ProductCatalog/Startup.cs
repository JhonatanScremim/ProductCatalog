using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Interfaces;
using ProductCatalog.Repositorys;
using ProductCatalog.Services;

namespace ProductCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
            
        public void ConfigureServices(IServiceCollection services)
        {
            //AddScoped: Toda vez que for pedido um StoreDataContext(Conexão com o banco) ele verifica se já existe um na memória, se não existir ele cria um 
            //AddTransient: Ele sempre cria uma nova instancia de StoreDataContext(Conexão com o banco), mesmo já existindo uma
            services.AddMvc();
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
