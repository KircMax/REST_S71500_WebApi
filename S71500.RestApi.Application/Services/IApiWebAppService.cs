using Siemens.Simatic.S7.Webserver.API.Models;

namespace S71500.RestApi.Application.Services
{
    public interface IApiWebAppService
    {
        Task<IEnumerable<ApiWebAppData>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ApiWebAppData> GetAsync(string webAppName, CancellationToken cancellationToken = default);
    }
}
