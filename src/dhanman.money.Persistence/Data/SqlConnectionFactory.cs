using B2aTech.CrossCuttingConcern.Core.Abstractions;
using Npgsql;
using System.Data;

namespace dhanman.money.Persistence.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly ConnectionString _connectionString;

    public SqlConnectionFactory(ConnectionString connectionString) => _connectionString = connectionString;

    public async Task<IDbConnection> CreateSqlConnectionAsync(CancellationToken cancellationToken)
    {
        var sqlConnection = new NpgsqlConnection(_connectionString);

        if (sqlConnection.State != ConnectionState.Open)
        {
            await sqlConnection.OpenAsync(cancellationToken);
        }

        return sqlConnection;
    }
}
