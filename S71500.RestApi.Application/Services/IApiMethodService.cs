using S71500.RestApi.Application.Models;

namespace S71500.RestApi.Application.Services
{
    public interface IApiMethodService
    {

        Task<IEnumerable<ApiMethod>> GetAllAsync(GetMethodOptionsBase options, CancellationToken cancellationToken = default);

        Task<ApiMethod> GetAsync(GetMethodOptions options, CancellationToken cancellationToken = default);
    }
}
