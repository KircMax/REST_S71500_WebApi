using S71500.RestApi.Application.Models;

namespace S71500.RestApi.Application.Repositories
{
    public interface IDocumentationDatabase
    {
        //Task<IEnumerable<ApiErrorCodeModel>> GetApiErrorCodesAsync(ApiMethod apiMethod);
        //Task<IEnumerable<ApiRequestParameter>> GetRequestParametersAsync(ApiMethod apiMethod);
        //Task<string> GetResultTypeAsync(ApiMethod apiMethod);

        Task<IEnumerable<ApiMethod>> GetApiMethodsAndErrorCodesAsync(IEnumerable<ApiMethod> methods);
        Task<IEnumerable<ApiMethod>> GetApiMethodsRequestParametersAsync(IEnumerable<ApiMethod> methods);
        Task<IEnumerable<ApiMethod>> GetApiMethodsResultTypesAsync(IEnumerable<ApiMethod> methods);
    }
}
