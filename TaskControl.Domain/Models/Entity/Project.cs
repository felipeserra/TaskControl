using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Domain.Core;
using Task.Domain.Models.Enum;

namespace Task.Domain.Models.Entity
{
    public class Project : Entity<Project>, IValidatable
    {
        public Customer Customer { get; private set; }
        public string Name { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public ProjectStatus Status { get; private set; }
        public IEnumerable<System.Threading.Tasks.Task> Tasks { get; private set; }

        private Project(Guid id, Customer customer, string name, DateTime registerDate, ProjectStatus status)
        {
            Id = id;
            Customer = customer;
            Name = name;
            RegisterDate = registerDate;
            Status = status;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}