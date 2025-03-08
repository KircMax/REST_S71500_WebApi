using S71500.RestApi.Application.Models;
using S71500.RestApi.Application.Repositories;

namespace S71500.RestApi.Application.Services
{
    public class ApiMethodService : IApiMethodService
    {
        private readonly IPlcConnectionFactory _plcConnectionFactory;
        private readonly IDocumentationDatabase _documentation;

        public ApiMethodService(IPlcConnectionFactory plcConnectionFactory)
        {
            _plcConnectionFactory = plcConnectionFactory;
        }

        public ApiMethodService(IPlcConnectionFactory plcConnectionFactory, IDocumentationDatabase documentation)
        {
            _plcConnectionFactory = plcConnectionFactory;
            _documentation = documentation;
        }

        public async Task<IEnumerable<ApiMethod>> GetAllAsync(GetMethodOptionsBase options, CancellationToken cancellationToken = default)
        {
            var requestHandler = await _plcConnectionFactory.CreateConnectionAsync(cancellationToken);
            var browsed = (await requestHandler.ApiBrowseAsync(cancellationToken)).Result;
            var results = browsed.Select(el => el.MapToMethod());
            if (options.IncludingParameters.HasValue && options.IncludingParameters.Value)
            {
                results = await _documentation.GetApiMethodsRequestParametersAsync(results);
            }
            if (options.IncludingErrorCodes.HasValue && options.IncludingErrorCodes.Value)
            {
                results = await _documentation.GetApiMethodsAndErrorCodesAsync(results);
            }
            if (options.IncludingResultType.HasValue && options.IncludingResultType.Value)
            {
                results = await _documentation.GetApiMethodsResultTypesAsync(results);
            }
            return results;
        }

        public async Task<ApiMethod> GetAsync(GetMethodOptions options, CancellationToken cancellationToken = default)
        {
            var requestHandler = await _plcConnectionFactory.CreateConnectionAsync(cancellationToken);
            var browsed = (await requestHandler.ApiBrowseAsync(cancellationToken)).Result;
            var results = browsed.Select(el => el.MapToMethod());
            var result = results.FirstOrDefault(el => el.Name == options.MethodName);
            if (result is null)
            {
                return null;
            }
            IEnumerable<ApiMethod> tmpResults = new List<ApiMethod>() { result };
            if (options.IncludingParameters.HasValue && options.IncludingParameters.Value)
            {
                tmpResults = await _documentation.GetApiMethodsRequestParametersAsync(tmpResults);
            }
            if (options.IncludingErrorCodes.HasValue && options.IncludingErrorCodes.Value)
            {
                tmpResults = await _documentation.GetApiMethodsAndErrorCodesAsync(tmpResults);
            }
            if (options.IncludingResultType.HasValue && options.IncludingResultType.Value)
            {
                tmpResults = await _documentation.GetApiMethodsResultTypesAsync(tmpResults);
            }
            return tmpResults.First();
        }
    }
}
