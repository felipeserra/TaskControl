using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Domain.Interfaces.Repositories.Core
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetAll();
    }
}