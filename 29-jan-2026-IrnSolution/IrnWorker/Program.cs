using IrnWorker;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
                       .LoadConfigurationFromFile("nlog.config")
                       .GetCurrentClassLogger();

try

{


    logger.Info("Starting Windows Service...");

    IHost host = Host.CreateDefaultBuilder(args)

        .ConfigureAppConfiguration((context, config) =>

        {

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            config.AddEnvironmentVariables();

        })

        .ConfigureServices((context, services) =>

        {
            services.AddHttpClient();
            services.AddHostedService<Worker>();
            services.AddScoped<RpaUploader>();
            //services.AddSingleton<RpaUploader>();

            //var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            //services.AddSingleton(connectionString);

            //var batchSizeDoc = context.Configuration.GetValue<int>("Batchsizedoc");
            //services.AddSingleton<object>(batchSizeDoc);

            //var FilePath = context.Configuration.GetValue<string>("FilePath");
            //services.AddSingleton<object>(FilePath);

            //var allowedServerIPs = context.Configuration.GetSection("AllowedServerIPs").Get<string[]>();
            //services.AddSingleton(allowedServerIPs);


        })

        .ConfigureLogging(logging =>

        {

            logging.ClearProviders();

            logging.AddConsole();

        })

        .UseNLog()

        .UseWindowsService()

        .Build();

    await host.RunAsync();

}

catch (Exception ex)

{

    logger.Error(ex, "Windows Service stopped due to exception");

    throw;

}

finally

{

    LogManager.Shutdown();

}


