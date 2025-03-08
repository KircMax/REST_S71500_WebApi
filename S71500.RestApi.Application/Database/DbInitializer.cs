using Dapper;

namespace S71500.RestApi.Application.Database
{
    public class DbInitializer
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public DbInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            // create method parameters table
            await connection.ExecuteAsync("""
            create table if not exists apimethodparameters (
            id int primary key not null,
            required boolean not null,
            datatype string not null,
            description string not null
            );
            """);

            FillMethodParametersAsync();

            // create api methods table
            await connection.ExecuteAsync("""
            create table if not exists apimethods (
            name string primary key not null,
            errorcodes string not null,
            parameters string not null);
            """);
        }

        private Task FillMethodParametersAsync()
        {
            // todo
            return Task.CompletedTask;
        }
    }
}
