using Flunt.Validations;
using System;
using Task.Domain.Core;

namespace Task.Domain.Models.Entity
{
    public class Customer : Entity<Customer>, IValidatable
    {
        public string CompanyName { get; private set; }

        private Customer(Guid id, string companyName)
        {
            Id = id;
            CompanyName = companyName;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(CompanyName, nameof(CompanyName), "Obrigatório informar o campo Razão Social.")
                .HasMaxLen(CompanyName, 40, nameof(CompanyName), "Razão Social não pode ter mais do que 40 caracteres.")
                );
        }

        public static EntityResult<Customer> TryCreateToInsert(string companyName)
            => TryCreateToUpdate(Guid.NewGuid(), companyName);

        private static EntityResult<Customer> TryCreateToUpdate(Guid id, string companyName)
            => EntityResult<Customer>.ValidateAndReturn(new Customer(id, companyName));
    }
}