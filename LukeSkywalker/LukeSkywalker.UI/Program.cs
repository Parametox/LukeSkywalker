using LukeSkywalker.UI;
using LukeSkywalker.UI.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

var logger = LogManager.GetCurrentClassLogger();
try
{
    var config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .Build();

    using var servicesProvider = new ServiceCollection()
        .AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
            loggingBuilder.AddNLog(config);
        })
        .RegisterServices()
        .AddSingleton<IConfiguration>(config)
        .BuildServiceProvider();

    WriteInfo("Application consumes Django rest api dedicated to Luke Skywalker character.");
    WriteInfo("It gets all movies were Luke plays, vehicles and starship he was");
    WriteInfo("Final json will be saved in location parametrized in configuration file.");
    WriteInfo($"The default value is C:\\Logs\\LukeSkywalker\\LukeSkywalker.json. Actual is: {config["jsonDestinationPath"]}");
    WriteInfo("Logs in console shows only informations, warnings,and errors (critical as well). \nDetails are logging directly into logfile. Default path is C:\\Logs\\LukeSkywalker\\LukeSkywalkerLogs\\LukeSkywalkerApp.log");
    WriteInfo("\nCreates by me - Piotr Cieślik\r\n");
    var runner = servicesProvider.GetService<IRunner>();

    Console.WriteLine("Write Id to get data and press ENTER.\n===[INFO] 1 for Luke Skywalker [INFO]===");

    //await runner.Run(int.Parse(Console.ReadLine()));
    await runner.Run(1);

    Console.WriteLine("Press ANY key to exit");
    Console.ReadKey();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    WriteError(ex.ToString());
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}

static void WriteInfo(string message)
{
    WirteInColor(message, ConsoleColor.Yellow);
}
static void WriteError(string message)
{
    WirteInColor(message, ConsoleColor.Red);
}
static void WirteInColor(string message, ConsoleColor messageColor)
{
    Console.ForegroundColor = messageColor;
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.White;
}