using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpecPattern.Framework.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using SpecPattern.Services;
using SpecPattern.Services.Implment;
using SpecPattern.Framework.Repository;
using SpecPattern.Framework.Repository.Implment;

namespace SpecPattern
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
            // Add framework services.
            services.AddMvc();

            services.AddSingleton(provider => Configuration);

            var dbType = DbTypes.MySql;
            if (Enum.TryParse(Configuration["Data:Type"], out dbType))
            {
                InitDbConnection(services, dbType);
            }

            InitServices(services);

            // AutoMapper Doc Url https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
            services.AddAutoMapper();

            // SignalR 
            services.AddSignalR(options => options.Hubs.EnableDetailedErrors = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSignalR();
        }

        private void InitDbConnection(IServiceCollection services, DbTypes type)
        {

            switch(type)
            {
                case DbTypes.MySql:
                    services.AddDbContext<SpecDbContext>(options =>
                        options.UseMySql(Configuration["Data:MySqlConnection"]));
                    break;
            }

        }

        private void InitServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieManagerService, MovieManagerService>();
        }

        private void ConfigCors(IApplicationBuilder app)
        {
            app.UseCors(
              builder => builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials())
              .UseStaticFiles()
              .UseWebSockets();
        }

    }
}
