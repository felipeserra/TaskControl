using System;

namespace Task.Domain.Interfaces.Repositories.Core
{
    public interface IWriteRepository<T> where T : class
    {
        System.Threading.Tasks.Task Add(T entity);

        System.Threading.Tasks.Task Update(T entity);

        System.Threading.Tasks.Task Delete(Guid id);
    }
}