using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventorySystem.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace InventorySystem.API
{
    /// <summary>
    /// Statup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Objecto configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="services">Servies app.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services configuration.
            services.AddSingleton<IConfiguration>(this.Configuration);

            // Load database context
            services.AddDbContext<InventorySystemContext>(
                opts => opts.UseInMemoryDatabase("InventorysystemDB")
                            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                );

            // Allow API for all sites. (Pending....)
            services.AddCors(c =>
            {
                c.AddDefaultPolicy(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            // Stores all information http request
            services.AddHttpContextAccessor();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventorySystem.API", Version = "v1" });

                // Enabled swagger anotation
                c.EnableAnnotations();

                // Xml documentation.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "InventorySystem.API.xml");
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(basePath, "InventorySystem.API.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvcCore().
               AddNewtonsoftJson(options =>
                   options.SerializerSettings.Converters.Add(new StringEnumConverter())
               )
               .AddJsonOptions(opts =>
               {
                   opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               })
               .AddApiExplorer();

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddApplication();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Enviroment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventorySystem.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
