using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;

namespace ProcsIT.Azure.Functions.DependencyInjection.Provider.Binding
{
    public class InjectAttributeBindingProvider : IBindingProvider
    {
        private IServiceProvider _serviceProvider;

        public InjectAttributeBindingProvider(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var parameterInfo = context.Parameter;
            var injectAttribute = parameterInfo.GetCustomAttribute<InjectAttribute>();
            if (injectAttribute == null)
            {
                return Task.FromResult<IBinding>(null);
            }

            //var container = _containerInitializer.GetOrCreateContainer();
            //var objectResolver = container.Resolve<IObjectResolver>();
            //return Task.FromResult<IBinding>(new InjectAttributeBinding(parameterInfo, objectResolver));
            return Task.FromResult<IBinding>(new InjectAttributeBinding(parameterInfo, _serviceProvider));
        }
    }
}