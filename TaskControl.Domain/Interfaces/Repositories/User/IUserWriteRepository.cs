using Task.Domain.Interfaces.Repositories.Core;

namespace Task.Domain.Interfaces.Repositories.User
{
    public interface IUserWriteRepository : IWriteRepository<Models.Entity.User>
    {
    }
}