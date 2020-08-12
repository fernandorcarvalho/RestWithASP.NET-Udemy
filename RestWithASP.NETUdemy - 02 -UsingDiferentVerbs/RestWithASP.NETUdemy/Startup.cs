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
using RestWithASP.NETUdemy.Business;
using RestWithASP.NETUdemy.Business.Implementation;
using RestWithASP.NETUdemy.Repository;
using RestWithASP.NETUdemy.Repository.Generic;
using RestWithASP.NETUdemy.Repository.Implementation;

namespace RestWithASP.NETUdemy
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger _logger;
        private IHostEnvironment _enviroment { get; }


        public Startup(IConfiguration configuration, IHostEnvironment enviroment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _enviroment = enviroment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<Model.Context.MySqlContext>(options => options.UseMySql(connectionString));

            if (_enviroment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed", ex);
                    throw ex;
                }
            }

            services.AddControllers();

            services.AddApiVersioning();

            // Dependecy Injection
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
