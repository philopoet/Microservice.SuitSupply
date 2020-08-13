using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Suitsupply.Framework.Core.DependencyInjection
{
    public class HttpContextServiceLocator : IDotNetCoreServiceLocator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public object GetService(Type serviceType)
        {
            return _httpContextAccessor.HttpContext.RequestServices.GetService(serviceType);
        }

        public T Resolve<T>()
        {
            return (T)_httpContextAccessor.HttpContext.RequestServices.GetService<T>();
        }

        public T Resolve<T>(Func<T, bool> selector)
        {
            return (T)ResolveAll<T>().FirstOrDefault(selector);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)_httpContextAccessor.HttpContext.RequestServices.GetServices<T>();
        }
    }
}
