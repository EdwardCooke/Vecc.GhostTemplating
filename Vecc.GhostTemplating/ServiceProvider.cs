using Vecc.GhostTemplating.Client;

namespace Vecc.GhostTemplating
{
    public static class ServiceProvider
    {
        public static IServiceProvider Build(string[] args)
        {
            // We use the webapplication builder because it registers everything necessary for building and using the views. Out of the box.
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddConsole();
            });

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<Program>(false)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            var configuration = configurationBuilder.Build();

            services.AddOptions();
            services.AddSingleton<GhostClient>();
            services.Configure<TemplatingOptions>(configuration.GetSection(nameof(TemplatingOptions)));
            services.AddMvcCore()
                .AddRazorViewEngine((o) =>
                {
                    o.ViewLocationFormats.Add("/Templates/{0}.cshtml");
                })
                .AddRazorRuntimeCompilation();

            return services.BuildServiceProvider();
        }
    }
}
