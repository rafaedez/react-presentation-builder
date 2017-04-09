using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using PresentationBuilder.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using PresentationBuilder.WebAPI.Models;
using System.IO;

namespace PresentationBuilder.WebAPI
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
            services.AddDbContext<PresentationContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddCors();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPresentationRepository, PresentationRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, PresentationContext presentationContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            string pathPresentations = Path.Combine(Directory.GetCurrentDirectory(), @"presentations");
            if (!Directory.Exists(pathPresentations)) Directory.CreateDirectory(pathPresentations);

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(pathPresentations)),
                RequestPath = new PathString("/presentations")
            });
            DbInitializer.Initialize(presentationContext);
        }
    }
}