using System;

namespace HexaCommerce.Domain.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public Type EntityType { get; }
        public object Id { get; }

        public EntityNotFoundException(Type entityType, object id)
            : base($"Entity of type '{entityType.Name}' with id '{id}' was not found.")
        {
            EntityType = entityType;
            Id = id;
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
} 