using inventario_api.Repository;
using inventario_api.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            services.AddScoped<ITipoInventarioRepository, TipoInventarioRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();
            services.AddScoped<ITomaInventarioRepository, TomaInventarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
            services.AddScoped<IArticuloTipoInventarioRepository, ArticuloTipoInventarioRepository>();
            services.AddScoped<IUsuarioAreaRepository, UsuarioAreaRepository>();

            services.AddCors(options => {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder => {
                                      builder
                                             .AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  }
                    );
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
