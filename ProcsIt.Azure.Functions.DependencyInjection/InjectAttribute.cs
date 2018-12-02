using System;
using Microsoft.Azure.WebJobs.Description;

namespace ProcsIT.Azure.Functions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : System.Attribute
    {
        public InjectAttribute()
        {
        }
    }
}
