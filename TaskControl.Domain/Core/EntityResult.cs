using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace TaskControl.Domain.Core
{
    public sealed class EntityResult<T> where T : Entity<T>, IValidatable
    {
        public bool Valid { get; private set; }
        public IEnumerable<Notification> Errors { get; private set; }
        public T Entity { get; private set; }

        public static EntityResult<T> ValidateAndReturn(T entity)
        {
            entity.Validate();
            return new EntityResult<T>
            {
                Valid = entity.Valid,
                Errors = entity.Notifications,
                Entity = entity.Valid ? entity : null
            };
        }
    }
}