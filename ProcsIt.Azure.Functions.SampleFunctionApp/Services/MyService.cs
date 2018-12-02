using Microsoft.Extensions.Logging;

namespace ProcsIT.Azure.Functions.SampleFunctionApp.Services
{
    public class MyService : IMyService
    {
        private readonly ILogger _logger;

        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
            _logger.LogInformation("Entered MyService");
        }

    }
}
