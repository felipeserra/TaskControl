using Flunt.Validations;
using System.Threading.Tasks;
using Task.Domain.Core;

namespace TaskControl.Domain.Interfaces.Service.Core
{
    public interface IRegisterDomainService<TEntity, TCommand> where TEntity : Entity<TEntity>, IValidatable where TCommand : class
    {
        Task<EntityResult<TEntity>> Create(TCommand command);
    }
}