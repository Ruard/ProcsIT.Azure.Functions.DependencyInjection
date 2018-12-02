using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ProcsIT.Azure.Functions.DependencyInjection.Provider.Value
{
    internal class InjectAttributeValueProvider : IValueProvider
    {
        private readonly ParameterInfo _parameterInfo;
        private IServiceProvider _serviceProvider;

        public InjectAttributeValueProvider(ParameterInfo parameterInfo, IServiceProvider serviceProvider)
        {
            _parameterInfo = parameterInfo;
            _serviceProvider = serviceProvider;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_serviceProvider.GetService(Type));
        }

        public string ToInvokeString()
        {
            return Type.ToString();
        }

        public Type Type => _parameterInfo.ParameterType;
    }
}