
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        string connectionStringTemplate = 
            _configuration.GetConnectionString("PostgresConnection")!;

        // it will get the variables from docker env

        string connectionString = connectionStringTemplate.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));


        // Create a new npg connection

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
}
