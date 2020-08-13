using System;
using System.Collections.Generic;
using System.Linq;

namespace SuitSupply.Framework.Core.Events
{
    public class EventBus : IEventBus
    {
        private IList<object> _subscribers { get; }=new List<object>();

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            _subscribers.Add(eventHandler);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            try
            {
                // TODO Log Event;
            }
            catch{ }

            try
            {
                var eligibleSubscribers = GetEligibleSubscribers<TEvent>();
                eligibleSubscribers.ForEach(s => s.Handle(@event));
            }
            catch (Exception ex)
            {
                try
                {
                    // TODO Log Exception;
                }
                catch { }

                throw ex;
            }
            
        }

        private List<IEventHandler<TEvent>> GetEligibleSubscribers<TEvent>() where TEvent : IEvent
        {
            return _subscribers
                .Where(e => (e as IEventHandler<TEvent>) != null)
                .OfType<IEventHandler<TEvent>>()
                .ToList();
        }
    }
}
