using System;

namespace HexaCommerce.Domain.Events
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public DateTime OccurredOn { get; private set; }
        public string EventType { get; private set; }

        protected BaseDomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            EventType = GetType().Name;
        }
    }
} 