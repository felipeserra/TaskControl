using Flunt.Validations;
using System;
using Task.Domain.Core;

namespace Task.Domain.Models.Entity
{
    public class User : Entity<User>, IValidatable
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private User(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;            
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Name, nameof(Name), "Obrigatório informar o campo Nome.")
                .HasMaxLen(Name, 50, nameof(Name), "Nome não pode ter mais do que 50 caracteres.")
                .IsNotNullOrEmpty(Email, nameof(Email), "Obrigatório informar o campo E-mail.")
                .HasMaxLen(Email, 50, nameof(Email), "E-mail não pode ter mais do que 50 caracteres.")
                .IsEmail(Email, nameof(Email), "E-mail informado está inválido.")
                .IsNotNullOrEmpty(Password, nameof(Password), "Obrigatório informar o campo Senha")
                );
        }
        
        public static EntityResult<User> TryCreateToInsert(string name, string email, string password)
            => TryCreateToUpdate(Guid.NewGuid(), name, email, password);

        public static EntityResult<User> TryCreateToUpdate(Guid id, string name, string email, string password)
            => EntityResult<User>.ValidateAndReturn(new User(
                id, name, email, password));
    }
}