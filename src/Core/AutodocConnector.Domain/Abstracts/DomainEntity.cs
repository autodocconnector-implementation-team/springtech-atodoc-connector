using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.Abstracts
{
    /// <summary>
    /// Abstract domain entity - parent of all domain entity
    /// </summary>
    public abstract class DomainEntity
    {
        private string? _id;
        /// <summary>
        /// Id of this entity
        /// </summary>
        public string? Id
        {
            get => _id;
            set
            {
                if (_id == null)
                {
                    _id = value;
                }
                else
                {
                    throw new Exceptions.DomainLayerException("Id is immutable!");
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
        /// <summary>
        /// Domain events
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Register a domain event
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Remove a domain event
        /// </summary>
        /// <param name="eventItem"></param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// Remove all domain events
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        /// <summary>
        /// True if this object entity is not persisted yet
        /// </summary>
        public bool IsTransient
        {
            get
            {
                return Id == null;
            }
        }

        /// <summary>
        /// Equals override
        /// </summary>
        /// <param name="obj">Equals with this</param>
        /// <returns>True if equals with obj parameter</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is DomainEntity))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            DomainEntity item = (DomainEntity)obj;
            if (item.IsTransient || IsTransient)
            {
                return false;
            }
            else
            {
                return item.Id == Id;
            }
        }

        int? _requestedHashCode;

        /// <summary>
        /// Get hash code override
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Bug", "S2328:\"GetHashCode\" should not reference mutable fields", Justification = "<Pending>")]  // Id is immutable in this implementation!
        public override int GetHashCode()
        {
            if (!IsTransient)
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = Id!.GetHashCode() ^ 31;
                }
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Equal operator (two domain entity is equivalent if its reference or it's ids is same or both null)
        /// </summary>
        /// <param name="left">Operator left side</param>
        /// <param name="right">Operator right side</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S3875:\"operator==\" should not be overloaded on reference types", Justification = "<Pending>")] // Valid comperassion way for all Model entities
        public static bool operator ==(DomainEntity left, DomainEntity right)
#pragma warning restore S3875 // "operator==" should not be overloaded on reference types
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DomainEntity left, DomainEntity right)
        {
            return !(left == right);
        }
    }
}