using System;
using System.Collections.Generic;

namespace Suitsupply.Framework.Core.DependencyInjection
{
    public interface IDotNetCoreContainer : IServiceProvider
    {
        T Resolve<T>();
        T Resolve<T>(Func<T, bool> selector);
        IEnumerable<T> ResolveAll<T>();
    }
}
