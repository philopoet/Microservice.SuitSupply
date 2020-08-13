using SuitSupply.Framework.Core.Events;
using System.Collections.ObjectModel;
using System.Linq;
using Suitsupply.Framework.Core.DependencyInjection;


namespace Suitsupply.Framework.Domain
{
    public class TrackableCollection<T> : Collection<T>
    {
        protected override void RemoveItem(int index)
        {
            var itemToBeRemoved = Items[index];
            base.RemoveItem(index);

            var eventBus = DotNetCoreServiceLocator.Current.Resolve<IEventBus>();
            eventBus.Publish(new NavigationItemDeletedEvent(itemToBeRemoved));
        }

        protected override void ClearItems()
        {
            var queue = Items.Select(item => new NavigationItemDeletedEvent(item)).ToList();
            base.ClearItems();

            var eventBus = DotNetCoreServiceLocator.Current.Resolve<IEventBus>();

            foreach (var @event in queue)
            {
                eventBus.Publish(@event);
            }
        }

    }
}
