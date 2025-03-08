using Siemens.Simatic.S7.Webserver.API.Models;

namespace S71500.RestApi.Contracts.Responses
{
    public class ApiWebAppsResponse
    {
        public required IEnumerable<ApiWebAppData> Items { get; init; } = Enumerable.Empty<ApiWebAppData>();
    }
}
