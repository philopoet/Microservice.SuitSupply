namespace SuitSupply.Framework.Core.Events
{
    public class NavigationItemDeletedEvent :IEvent
    {
        public NavigationItemDeletedEvent(object itemToBeDeleted)
        {
            this.ItemToBeDeleted = itemToBeDeleted;
        }

        public object ItemToBeDeleted { get; private set; }
    }
}
