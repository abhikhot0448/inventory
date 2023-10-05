using B2aTech.CrossCuttingConcern.Core.Abstractions;
using Dapper;
using System.Data;

namespace dhanman.money.Persistence.Data;

internal sealed class DbExecutor : IDbExecutor
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public DbExecutor(ISqlConnectionFactory sqlConnectionFactory) => _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<T[]> QueryAsync<T>(string sql, object parameters)
    {
        using IDbConnection connection = await _sqlConnectionFactory.CreateSqlConnectionAsync();

        IEnumerable<T> result = await connection.QueryAsync<T>(sql, parameters);

        return result.ToArray();
    }
}
