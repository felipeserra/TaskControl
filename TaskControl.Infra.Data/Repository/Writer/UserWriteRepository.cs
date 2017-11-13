using Task.Domain.Interfaces.Repositories.User;
using Task.Domain.Models.Entity;
using TaskControl.Infra.Data.Repository.Common;

namespace TaskControl.Infra.Data.Repository.Writer
{
    public sealed class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
    }
}