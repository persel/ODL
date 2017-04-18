using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;
using ODL.WebApi;
using Serilog;
using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Model;

namespace ODL.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //if (env.IsEnvironment("Development"))
            ///{
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            //}

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; } 

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);
            services.AddScoped(_ => new ODLDbContext(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IOrganisationService, OrganisationService>();
            services.AddScoped<IAdressService, AdressService>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAvtalRepository, AvtalRepository>();
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IAdressRepository, AdressRepository>();
            services.AddScoped<IAdressVariantRepository, AdressVariantRepository>();

            services.AddScoped(contextFactory);

            // Lägg till service och skapa Policy med options
            // Se: Se: https://weblog.west-wind.com/posts/2016/Sep/26/ASPNET-Core-and-CORS-Gotchas
            // https://elanderson.net/2016/11/cross-origin-resource-sharing-cors-in-asp-net-core/
            // (Hanterar CORS - se också app.UseCors i Configure)
            // TODO: Se till att peka ut bara den specifika domänen och HTTP Verb 'Options'
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Ser till så att man har lagt till Alias/AnvandarNamn i headern innan man anropar en tjänst
            //Ingen mer kontroll för tillfället 
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ValidUserName",
                    policy => policy.Requirements.Add(
                        new MinimumRequirement(
                            anvandarNamn: "",
                            applikation: "PostOmbud",
                            namn: "")
                    ));
            });

            services.AddSingleton<IAuthorizationHandler, MinimumRequirementHandler>();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc(config =>
                {
                    config.Filters.Add(typeof(GlobalExceptionFilter));
                }
            );
            
            //Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            // TODO: Applicera specifikt på Controllers mha [EnableCors("CorsPolicy")]
            // Se även anropet till services.AddCors i ConfigureServices
            app.UseCors("CorsPolicy");

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
            
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Error() // TODO: Konfigurera detta!
                    .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs/log-{Date}.txt"))
                    .CreateLogger();

            loggerFactory.AddSerilog();

        }

        private readonly Func<IServiceProvider, IContext> contextFactory = x =>
        {
            //Getting our context out of the container.
            var context = x.GetService<ODLDbContext>();
            return context;
        };
    }
}
