using ProcsIT.Azure.Functions.DependencyInjection.Provider.Value;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ProcsIT.Azure.Functions.DependencyInjection.Provider.Binding
{
    public class InjectAttributeBinding : IBinding
    {
        private readonly ParameterInfo _parameterInfo;
        private IServiceProvider _serviceProvider;

        public InjectAttributeBinding(ParameterInfo parameterInfo, IServiceProvider serviceProvider)
        {
            _parameterInfo = parameterInfo;
            _serviceProvider = serviceProvider;
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return Task.FromResult<IValueProvider>(new InjectAttributeValueProvider(_parameterInfo, _serviceProvider));
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            return Task.FromResult<IValueProvider>(new InjectAttributeValueProvider(_parameterInfo, _serviceProvider));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameterInfo.Name,
                DisplayHints = new ParameterDisplayHints
                {
                    Description = "Inject services",
                    DefaultValue = "Inject services",
                    Prompt = "Inject services"
                }
            };
        }

        public bool FromAttribute => true;
    }
}