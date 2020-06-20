using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Artillery.Data
{
    public class BaseDapperRepository
    {
        private readonly IDbConnection _conn;

        public BaseDapperRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<List<T>> QueryAsync<T>(string query, object parameters = null)
        {
            try
            {
                return (await _conn.QueryAsync<T>(query, parameters)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }

        public async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
        {
            try
            {
                return await _conn.QuerySingleAsync<T>(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<T> QueryFirstAsync<T>(string query, object parameters = null)
        {
            try
            {
                return await _conn.QueryFirstAsync<T>(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<int> ExecuteAsync(string query, object parameters = null)
        {
            try
            {
                return await _conn.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
