using Microsoft.EntityFrameworkCore;
using System;
using Task.Domain.Interfaces.Repositories.Core;
using TaskControl.Infra.Data.DataContext;

namespace TaskControl.Infra.Data.Repository.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly TaskControlContext _context;
        private readonly DbSet<T> _dbSet;

        public WriteRepository()
        {
            _context = new TaskControlContext();
            _dbSet = _context.Set<T>();
        }

        public async System.Threading.Tasks.Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}