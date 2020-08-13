using Suitsupply.Framework.Core.DependencyInjection;
using SuitSupply.Framework.Core.Events;

namespace Suitsupply.Framework.Domain
{
    public class AggregateRoot<TKey, TEntity>: Entity<TKey, TEntity>
        where TEntity : Entity<TKey, TEntity>
    {
        protected IEventBus EventBus { get; } = DotNetCoreServiceLocator.Current.Resolve<IEventBus>();
    }
}
