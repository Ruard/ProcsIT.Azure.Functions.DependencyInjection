using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProcsIT.Azure.Functions.DependencyInjection;
using ProcsIT.Azure.Functions.DependencyInjection.Provider.Config;
using ProcsIT.Azure.Functions.SampleFunctionApp.Services;
using System;

[assembly: WebJobsStartup(typeof(WebJobsExtensionStartup))]

namespace ProcsIT.Azure.Functions.DependencyInjection
{
    public class WebJobsExtensionStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory) //executionContext.FunctionAppDirectory
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            builder.AddExtension<InjectAttributeExtensionConfigProvider>();

            var serviceCollection = (ServiceCollection)builder.Services;

            serviceCollection.AddSingleton(typeof(ILogger), typeof(LoggingService));
            serviceCollection.AddSingleton(typeof(ILogger<>), typeof(GenericLoggingService<>));

            serviceCollection.AddScoped<IMyService, MyService>();
        }
    }
}
