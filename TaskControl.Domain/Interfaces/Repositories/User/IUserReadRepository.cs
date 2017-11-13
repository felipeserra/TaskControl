using System.Threading.Tasks;
using Task.Domain.Interfaces.Repositories.Core;

namespace Task.Domain.Interfaces.Repositories.User
{
    public interface IUserReadRepository : IReadRepository<Models.Entity.User>
    {
        Task<Models.Entity.User> GetByEmail(string email);
    }
}