using System;

namespace TaskControl.Domain.Commands.User
{
    public sealed class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
            => Id = id;
    }
}