using AutoMapper;
using CanWeFixIt.EntityFramework;
using CanWeFixIt.EntityFramework.DataSeeders;
using CanWeFixIt.Service;
using CanWeFixIt.Service.Services;
using CanWeFixIt.Service.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CanWeFixItApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private SqliteConnection _connection;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            _connection = new SqliteConnection(Configuration.GetConnectionString("Default"));
            _connection.Open();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(_connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CanWeFixItApi", Version = "v1" });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationAutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IDbSeeder, CanWeFixItDbSeeder>();
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IMarketDataService, MarketDataService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CanWeFixItApi v1"));
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbSeeder = services.GetService<IDbSeeder>();
                _ = dbSeeder?.ExecuteSeeder();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}