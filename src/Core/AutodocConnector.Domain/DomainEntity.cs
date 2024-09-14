using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain
{
    /// <summary>
    /// Abstract domain entity - parent of all domain entity
    /// </summary>
    public abstract class DomainEntity
    {
        /// <summary>
        /// Id of this entity
        /// </summary>
        public string? Id
        {
            get => Id;
            set
            {
                if (Id == null)
                {
                    Id = value;
                }
                else
                {
                    throw new DomainException("Id is immutable!");
                }
            }
        }

        /// <summary>
        /// This entity created at
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// TODO: Change to Identity user domainobject!
        /// </summary>
        public string? CreatedBy { get; set; }
        
        /// <summary>
        /// This entity is active or not
        /// </summary>
        public bool Active { get; set; } = false;

        private List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return this.Id == null;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is DomainEntity))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            DomainEntity item = (DomainEntity)obj;
            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id == this.Id;
            }
        }

        int? _requestedHashCode;

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = this.Id!.GetHashCode() ^ 31;
                }
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public static bool operator ==(DomainEntity left, DomainEntity right)
        {
            if (Object.Equals(left, null))
            {
                return Object.Equals(right, null) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(DomainEntity left, DomainEntity right)
        {
            return !(left == right);
        }
    }
}