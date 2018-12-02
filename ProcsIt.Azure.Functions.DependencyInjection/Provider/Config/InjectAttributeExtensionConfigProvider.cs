using ProcsIT.Azure.Functions.DependencyInjection.Provider.Binding;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;

namespace ProcsIT.Azure.Functions.DependencyInjection.Provider.Config
{
    public class InjectAttributeExtensionConfigProvider : IExtensionConfigProvider
    {
        private InjectAttributeBindingProvider _bindingProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IServiceProvider _serviceProvider;

        public InjectAttributeExtensionConfigProvider(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            //constructor takes over loggerfactory instance 
            //that is directly injected only by webjobs 3.x
            _loggerFactory = loggerFactory;
            _serviceProvider = serviceProvider;
        }

        public InjectAttributeExtensionConfigProvider()
        {
            //constructor is necessary due to implemenatation of webjobs for .net framework
            //which is not going to inject loggerfactory
        }

        public void Initialize(ExtensionConfigContext context)
        {
            _bindingProvider = new InjectAttributeBindingProvider(_loggerFactory, _serviceProvider);
            context.AddBindingRule<InjectAttribute>().Bind(_bindingProvider);
        }
    }
}