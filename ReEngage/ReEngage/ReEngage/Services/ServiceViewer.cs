using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReEngage.Services
{
    public interface IServiceViewer
    {
        string GetServiceInfo();
    }

    public class ServiceViewer : IServiceViewer
    {
        IServiceCollection _descriptions;


        public ServiceViewer(IServiceCollection collection)
        {
            _descriptions = collection;
        }

        public string GetServiceInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"total count: {_descriptions.Count}");
            foreach (var item in _descriptions)
            {
                builder.AppendLine($"ServiceType:{item.ServiceType?.ToString()}  ImplementationType:{item.ImplementationType?.ToString()} Lifetime:{item.Lifetime.ToString()} ImplementationInstance:{item.ImplementationInstance?.ToString()}");
            }

            return builder.ToString();
        }
    }
}
