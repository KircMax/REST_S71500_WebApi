using S71500.RestApi.Application.Repositories;
using Siemens.Simatic.S7.Webserver.API.Models;

namespace S71500.RestApi.Application.Services
{
    public class ApiWebAppService : IApiWebAppService
    {
        private readonly IPlcConnectionFactory _plcConnectionFactory;

        public ApiWebAppService(IPlcConnectionFactory plcConnectionFactory)
        {
            _plcConnectionFactory = plcConnectionFactory;
        }

        public async Task<IEnumerable<ApiWebAppData>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var reqHandler = await _plcConnectionFactory.CreateConnectionAsync(cancellationToken);
            var allBrowsed = (await reqHandler.WebAppBrowseAsync(cancellationToken: cancellationToken)).Result;
            return allBrowsed.Applications;
        }

        public async Task<ApiWebAppData> GetAsync(string webAppName, CancellationToken cancellationToken = default)
        {
            var reqHandler = await _plcConnectionFactory.CreateConnectionAsync(cancellationToken);
            var allBrowsed = (await reqHandler.WebAppBrowseAsync(webAppName, cancellationToken: cancellationToken)).Result;
            return allBrowsed.Applications.FirstOrDefault();
        }
    }
}
