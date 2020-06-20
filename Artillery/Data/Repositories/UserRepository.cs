using Artillery.Domain.Entity;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Data.Repositories
{
    public class UserRepository : BaseDapperRepository
    {
        public UserRepository(IDbConnection conn) : base(conn)
        {
        }

        public async Task<List<User>> GetAll()
        {
            return await QueryAsync<User>("SELECT ID, NAME, USER_NAME AS USERNAME, EMAIL, CREATION FROM ARTILLERY.USERS");
        }

        public async Task<User> GetById (int id)
        {
            return await QuerySingleAsync<User>("SELECT ID, NAME, USER_NAME AS USERNAME, EMAIL, CREATION FROM ARTILLERY.USERS WHERE ID = @id", new { id });
        }

        public async Task<int> AddUser(User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NAME", user.Name, DbType.AnsiString);
            parameters.Add("USER_NAME", user.UserName, DbType.AnsiString);
            parameters.Add("EMAIL", user.Email, DbType.AnsiString);

            return await ExecuteAsync("INSERT INTO ARTILLERY.USERS (NAME, USER_NAME, EMAIL) VALUES (@NAME, @USER_NAME, @EMAIL )", parameters);
        }
    }
}
