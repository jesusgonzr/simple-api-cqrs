using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace InventorySystem.Domain.Commons
{
    /// <summary>
    /// Entity base class.
    /// </summary>
    public abstract class Entity
    {
        private int? requestedHashCode;
        private Guid id;
        private List<INotification>? domainEvents;

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public virtual Guid Id
        {
            get
            {
                return this.id;
            }

            protected set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets Events.
        /// </summary>
        public IReadOnlyCollection<INotification>? DomainEvents => this.domainEvents?.AsReadOnly();

        /// <summary>
        /// Gets comparable object.
        /// </summary>
        /// <param name="left">Entity object left.</param>
        /// <param name="right">Entity object right.</param>
        /// <returns>Returns true o false.</returns>
        public static bool operator ==(Entity left, Entity right)
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
        /// Gets comparable object.
        /// </summary>
        /// <param name="left">Entity object left.</param>
        /// <param name="right">Entity object right.</param>
        /// <returns>Returns true o false.</returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Add domain events.
        /// </summary>
        /// <param name="eventItem">Event item.</param>
        public void AddDomainEvent(INotification eventItem)
        {
            this.domainEvents ??= new List<INotification>();
            this.domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Remove domain events.
        /// </summary>
        /// <param name="eventItem">Event item.</param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            this.domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// Clear domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            this.domainEvents?.Clear();
        }

        /// <summary>
        /// Is transient.
        /// </summary>
        /// <returns>Returns true o false.</returns>
        public bool IsTransient()
        {
            return this.Id == default;
        }

        /// <summary>
        /// Gets comparable object.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Returns true o false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id == this.Id;
            }
        }

        /// <summary>
        /// Get HashCode.
        /// </summary>
        /// <returns>Returns int value.</returns>
        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this.requestedHashCode.HasValue)
                {
                    this.requestedHashCode = this.Id.GetHashCode() ^ 31;
                }

                return this.requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }
    }
}
