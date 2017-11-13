using System;

namespace TaskControl.Domain.Commands.User
{
    public class UserCommand
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}