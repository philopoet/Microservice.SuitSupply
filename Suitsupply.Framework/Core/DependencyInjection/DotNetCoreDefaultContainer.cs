using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Suitsupply.Framework.Core.DependencyInjection
{
    public class DotNetCoreDefaultContainer : IDotNetCoreContainer
    {
        public readonly IServiceProvider ServiceProvider;

        public DotNetCoreDefaultContainer(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);
        }

        public T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public T Resolve<T>(Func<T, bool> selector)
        {
            return ResolveAll<T>().FirstOrDefault(selector);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return ServiceProvider.GetServices<T>();
        }
    }
}
