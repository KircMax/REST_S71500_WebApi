using S71500.RestApi.Application.Models;

namespace S71500.RestApi.Contracts.Responses
{
    public class ApiMethodsResponse
    {
        public required IEnumerable<ApiMethod> Items { get; init; } = Enumerable.Empty<ApiMethod>();
    }
}
