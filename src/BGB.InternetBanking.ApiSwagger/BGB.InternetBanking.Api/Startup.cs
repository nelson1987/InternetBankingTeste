using AutoMapper;
using BGB.InternetBanking.Api.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace BGB.InternetBanking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mapear o repositorio de produto
            //injeção de dependencia..
            services.RegisterServices();
            //configuração do JWT (Autenticação)
            services.RegisterServices(Configuration);

            services.AddMvc();
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //registrando a classe DomainProfile do AutoMapper
            Mapper.Initialize(m =>
            {
                m.AddProfile<EntityToModelProfile>();
                m.AddProfile<ModelToEntityProfile>();
            });

            services.AddRouting();

            services.AddApiVersioning(x =>
            {
                x.ReportApiVersions = true;
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "WEB API Asp.Net Core - Banco Guanabara",
                    Version = "v1",
                    Description = "API auxiliar de manutenção do Internet Banking",
                    Contact = new Contact
                    {
                        Name = "COTI Informática",
                        Url = "http://cotiinformatica.com.br"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json",
                "Projeto Asp.Net Core WEB API");
            });

            //app.UseHttpsRedirection();
            app.UseMvc(routes =>
                routes.MapRoute(
                    name: "ApiWithAction",
                    template: "api/v{version}/{controller}/{action}/{id?}"
                )
            );

        }
    }
}
