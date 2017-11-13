using Flunt.Validations;
using System.Threading.Tasks;
using Task.Domain.Core;

namespace TaskControl.Domain.Interfaces.Service.Core
{
    public interface IUpdateDomainService<TEntity, TCommand> where TEntity : Entity<TEntity>, IValidatable where TCommand : class
    {
        Task<EntityResult<TEntity>> Update(TCommand command);
    }
}