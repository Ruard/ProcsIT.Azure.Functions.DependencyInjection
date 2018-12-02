using Microsoft.Extensions.Logging;

namespace Document.Export.Function.Services
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
