using Siemens.Simatic.S7.Webserver.API.Services.RequestHandling;

namespace S71500.RestApi.Application.Repositories
{
    public interface IPlcConnectionFactory
    {
        Task<IApiRequestHandler> CreateConnectionAsync(CancellationToken cancellationToken = default);
    }

    public class PlcConnectionFactory : IPlcConnectionFactory
    {
        public Func<Task<IApiRequestHandler>> GetRequestHandler;

        public PlcConnectionFactory()
        {

        }

        public Task InitializeAsync(Func<Task<IApiRequestHandler>> getRequestHandler, CancellationToken cancellationToken = default)
        {
            GetRequestHandler = getRequestHandler;
            return Task.CompletedTask;
        }

        public async Task<IApiRequestHandler> CreateConnectionAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetRequestHandler();
            return result;
        }
    }

}
