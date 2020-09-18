using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using ConferencePlanner.WinUi.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(ServiceProvider.GetService<FormLogin>()); 
        }


        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<HomePage>();
            services.AddScoped<MainForm>();
            services.AddScoped<Form2>();
            services.AddScoped<FormLogin>();
            services.AddScoped<IGetDemoRepository, GetDemoRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IConferenceTypeRepository, ConferenceTypeRepository>();
            services.AddScoped<IConferenceCategoryRepository, ConferenceCategoryRepository>();
            services.AddScoped<IConferenceCityRepository, ConferenceCityRepository>();
            services.AddScoped<IConferenceSpeakerRepository, ConferenceSpeakerRepository>();
            services.AddScoped<IConferenceTypeRepository, ConferenceTypeRepository>();
            services.AddScoped<IConferenceAttendanceRepository, ConferenceAttendanceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IConferenceLocationRepository, ConferenceLocationRepository>();


            services.AddSingleton<SqlConnection>(a =>
            {
                SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            });
            ServiceProvider = services.BuildServiceProvider();

            //buna
        }
    }
}


//TestPush
