using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Splunk;

namespace ProjectCleanArch.Ioc
{
    public static class CreateLogger
    {
        public static void CreateLoggingSingleton(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                 .Enrich.WithProperty("Project", "ProjectCleanArch")
                 .Enrich.WithProperty("Environment", "Local")
                 .WriteTo.Seq("http://localhost:5341/")
                 .WriteTo.EventCollector("http://localhost:8000/services/collector",
                                         "e7e61264-81cb-4ac9-b721-f482a48a1cb8",
                                          new CompactSplunkJsonFormatter())
                 .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
