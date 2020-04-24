using Chefao.Core.DataService.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Chefao.WebApi
{
    using Chefao.DataServices.EFCore;
    using Chefao.DataServices.EFCore.DataContext;
    using Core.DataService;
    using Core.DomainService;
    using DataServices.Interfaces;
    using DomainServices;
    using EFCore.Setup;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;

            DbContextDataInitializer.Initialize(new SqlServerDbContext(Configuration));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //generic services
            //services.AddDbContext<DbContext>(options => new SqlServerDbContext(Configuration) );

            services.AddScoped<DbContext, SqlServerDbContext>(x =>
            {
                return new SqlServerDbContext(Configuration);
            });

            services.AddTransient(typeof(IEntityDataService<>), typeof(EntityDataService<>));

            services.AddTransient(typeof(DomainService<,>));

            //custom services

            services.AddScoped<AppDbContext, SqlServerDbContext>(x => 
            {
                return new SqlServerDbContext(Configuration);
            });
            services.AddDbContext<AppDbContext>(options => new SqlServerDbContext(Configuration));

            services.AddTransient<ILojaDataService, LojaDataService>();
            services.AddTransient<LojaDomainService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Chefao.WebApi",
                    Version = "v1",
                    Description = "Komercialize E-commerce API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Leo Lima",
                        Email = "leolima@leolima77.com.br",
                        Url = new System.Uri("https://komercialize.com.br")
                    }
                });
            });

            services.AddMvc();
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api");
                c.RoutePrefix = string.Empty;
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
