using Dapper;
using System.Threading.Tasks;
using Task.Domain.Interfaces.Repositories.User;
using Task.Domain.Models.Entity;
using TaskControl.Infra.Data.Repository.Common;

namespace TaskControl.Infra.Data.Repository.Reader
{
    public sealed class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryFirstAsync<User>(
                    sql: "SELECT * FROM Users WHERE Email = @email",
                    param: new { email = email });
            }
        }
    }
}