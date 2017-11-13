using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Task.Domain.Interfaces.Repositories.Core;
using TaskControl.Infra.Data.Util;

namespace TaskControl.Infra.Data.Repository.Common
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> GetAll()
        {
            using (var connection = GetConnection())
                return await connection.GetAllAsync<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            using (var connection = GetConnection())
                return await connection.GetAsync<T>(id);
        }

        protected SqlConnection GetConnection()
        {
            var connection = new SqlConnection(Configuration.GetDefaultConnectionString());
            connection.Open();
            return connection;
        }
    }
}