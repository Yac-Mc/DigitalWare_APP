using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConexionDB");
        }

        // use for buffered queries that return a type
        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await getData(connection);
        }

        // use for buffered queries that do not return a type
        protected async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await getData(connection);
        }

        // use for non-buffered queries that return a type
        protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData, Func<TRead, Task<TResult>> process)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var data = await getData(connection);
            return await process(data);
        }
    }
}
