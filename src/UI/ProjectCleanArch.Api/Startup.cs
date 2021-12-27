using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjectCleanArch.Api.Middleware;
using ProjectCleanArch.Ioc;
using Serilog;
using Serilog.Sinks.Splunk;

namespace ProjectCleanArch.Api
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
            services.AddControllers();
            services.AddInfrasTructure(Configuration);

            // Configurando o Log SEQ e Splunk [Ainda falta finalizar o Splunk]
            Log.Logger = new LoggerConfiguration()
                 .Enrich.WithProperty("Project", "ProjectCleanArch")
                 .Enrich.WithProperty("Environment", "Local")
                 .WriteTo.Seq("http://localhost:5341/")
                 .WriteTo.EventCollector("http://localhost:8000/services/collector",
                                         "e7e61264-81cb-4ac9-b721-f482a48a1cb8", 
                                          new CompactSplunkJsonFormatter())
                 .CreateLogger();

            services.AddSingleton(Log.Logger);


            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Clean Arch", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleMediator v1"));
            }

            app.UseRouting();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
