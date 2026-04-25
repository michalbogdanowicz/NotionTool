using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NotionToolUI
{
    internal static class Program
    {
        public static BusinessLogic.Business? business;
        private static readonly string KEY = "token";
        ///// <summary>
        /////  The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    business = new BusinessLogic.Business();
        //    business.Init(BusinessLogic.SettingsManager.ReadSetting(KEY));
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Form1());

        //}


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main() // <-- 'async Task' instead of 'void'
        {
            business = new BusinessLogic.Business();
            business.Init(BusinessLogic.SettingsManager.ReadSetting(KEY));
            // To customize application configuration such as
            // set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using IHost host = CreateHost();
            await host.StartAsync();

            IHostApplicationLifetime lifetime =
                host.Services.GetRequiredService<IHostApplicationLifetime>();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetRequiredService<Form1>();

                Application.Run(mainForm);
            }

            lifetime.StopApplication();
            await host.WaitForShutdownAsync();
        }

        private static IHost CreateHost()
        {
            string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSingleton<Form1>();

            //builder.Services.Configure<SampleOptions>(
            //    builder.Configuration.GetSection(nameof(SampleOptions))
            //);

            return builder.Build();
        }
    }
}