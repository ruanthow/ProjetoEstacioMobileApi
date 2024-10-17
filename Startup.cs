using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoEstacio.DbApllication;
using ProjetoEstacio.Repository;
using ProjetoEstacio.Services;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjetoEstacio
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), 
                    new MySqlServerVersion(new Version(5, 0, 4)))
                     
                ); // Certifique-se de ajustar a versão do MySQL para a que você está usando.

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("PermitirFrontend", builder =>
                {
                    builder.WithOrigins("http://localhost:5000") // Permitir apenas essa origem
                        .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
                        .AllowAnyHeader(); // Permitir qualquer cabeçalho
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Your API", 
                    Version = "v1",
                    Description = "Uma descrição curta da sua API"
                });
            });
            
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
                    c.RoutePrefix = string.Empty; // Exibe o Swagger na raiz do aplicativo
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("PermitirFrontend");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
