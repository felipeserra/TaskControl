using Flunt.Notifications;
using System;

namespace TaskControl.Domain.Core
{
    public abstract class Entity<T> : Notifiable where T : Entity<T>
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as T;

            if (ReferenceEquals(this, compareTo))
                return true;

            return !ReferenceEquals(null, compareTo) && compareTo.Id.Equals(Id) && EqualsCore(compareTo);
        }

        protected abstract bool EqualsCore(T other);

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ GetHashCodeCore();
            }
        }

        protected abstract int GetHashCodeCore();
    }
}