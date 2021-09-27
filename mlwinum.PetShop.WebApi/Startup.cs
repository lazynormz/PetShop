using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.IValidator;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Domain.Services;
using mlwinum.PetShop.Domain.Validator;
using mlwinum.PetShop.Infrastructure.Data;
using mlwinum.PetShop.Infrastructure.Data.Repositories;

namespace mlwinum.PetShop.WebApi
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "mlwinum.PetShop.WebApi", Version = "v1"});
            });

            ILoggerFactory loggerFact = LoggerFactory.Create(builder => builder.AddConsole());

            services.AddDbContext<PetApplicationContext>(options => options.UseLoggerFactory(loggerFact).UseSqlite("Data Source=database.db"));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService,PetTypeService>();
            services.AddScoped<IValidator, Validator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mlwinum.PetShop.WebApi v1"));

                using (IServiceScope scope = app.ApplicationServices.CreateScope())
                {
                    DbContext ctx = scope.ServiceProvider.GetService<PetApplicationContext>();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseCors(options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}