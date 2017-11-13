using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Domain.Models.Interfaces.Service.Core
{
    public interface IReadDomainService<T> where T : class
    {
        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetAll();
    }
}