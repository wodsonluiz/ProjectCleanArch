using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace ProjectCleanArch.Ioc
{
    public static class DependencyInjectionLogger
    {
        public static void CreateLoggingSingleton(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(configuration.GetSection("LogFile").GetSection("Path").Value,
                               restrictedToMinimumLevel: GetLevelLogg(configuration.GetSection("LogFile").GetSection("Path").Value))
                 .Enrich.WithProperty("Project", configuration.GetSection("LogSeq").GetSection("Project").Value)
                 .Enrich.WithProperty("Environment", configuration.GetSection("LogSeq").GetSection("Env").Value)
                 .WriteTo.Seq(configuration.GetSection("LogSeq").GetSection("Host").Value)
                 .CreateLogger();

            services.AddSingleton(Log.Logger);
        }

        private static LogEventLevel GetLevelLogg(string configuration) => configuration switch
        {
            "Debug" => LogEventLevel.Debug,
            "Information" => LogEventLevel.Information,
            _ => LogEventLevel.Verbose,
        };
    }
}
