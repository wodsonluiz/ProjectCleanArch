using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ProjectCleanArch.Ioc
{
    public static class CreateLogger
    {
        public static void CreateLoggingSingleton(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                 .Enrich.WithProperty("Project", configuration.GetSection("LogSeq").GetSection("Project").Value)
                 .Enrich.WithProperty("Environment", configuration.GetSection("LogSeq").GetSection("Env").Value)
                 .WriteTo.Seq(configuration.GetSection("LogSeq").GetSection("Host").Value)
                 .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
