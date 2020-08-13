using Suitsupply.Framework.Domain;
using System;

namespace Suitsupply.Domain.Contracts.Suits
{
    public class AlterationFinishedEvent : DomainEvent
    {
        public Guid SuitId { get; set; }
    }
}
