using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using ConferencePlanner.Repository.Ef.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ConferencePlanner.Api.Swagger;
using Microsoft.OpenApi.Models;


namespace ConferencePlanner.Api
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
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<neverseaContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetService<IConfiguration>();
                    var connectionString = configuration.GetConnectionString("DbConnection");

                    options.UseSqlServer(connectionString, a => a.EnableRetryOnFailure())
                    .UseInternalServiceProvider(serviceProvider);
                });

            services.AddScoped<IGetDemoRepository, GetDemoRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<IConferenceLocationRepository, ConferenceLocationRepository>();
            services.AddScoped<ICountryRepository, ConferenceCountryRepository>();
            services.AddScoped<IConferenceCityRepository, ConferenceCityRepository>();
            services.AddScoped<IDistrictRepository, ConferenceDistrictRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IConferenceSpeakerRepository, ConferenceSpeakerRepository>();
            services.AddScoped<IConferenceTypeRepository, ConferenceTypeRepository>();
            services.AddScoped<IConferenceCategoryRepository, ConferenceCategoryRepository>();
            services.AddScoped<IConferenceAttendanceRepository, ConferenceAttendanceRepository>();
            services.AddScoped<IConferenceXSpeakerRepository, ConferenceXSpeakerRepository>();

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer {Url = $"http://{httpReq.Host.Value}{httpReq.PathBase.Value}"}
                    };
                });
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Planner API");
            });
        }
    }
}



// push test