using SuitSupply.Framework.Core.Events;
using System;

namespace Suitsupply.Framework.Domain
{
    public abstract class DomainEvent: IEvent
    {
        public DomainEvent()
        {
            OccuredOn = DateTime.Now;
        }
        public DateTime OccuredOn { get; private set; }
    }
}
