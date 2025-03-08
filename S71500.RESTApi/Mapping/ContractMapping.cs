using S71500.RestApi.Application.Models;
using S71500.RestApi.Contracts.Requests;
using S71500.RestApi.Contracts.Responses;
using Siemens.Simatic.S7.Webserver.API.Models;

namespace S71500.RestApi.Mapping
{
    public static class ContractMapping
    {

        public static ApiMethod MapToMethod(this ApiClass apiClass)
        {
            return new ApiMethod()
            {
                Name = apiClass.Name
            };
        }

        public static ApiMethodsResponse MapToResponse(this IEnumerable<ApiMethod> methods)
        {
            return new ApiMethodsResponse
            {
                Items = methods,
            };
        }

        public static ApiWebAppsResponse MapToResponse(this IEnumerable<ApiWebAppData> webApps)
        {
            return new ApiWebAppsResponse
            {
                Items = webApps
            };
        }

        public static GetMethodOptionsBase MapToOptionsBase(this GetMethodRequestBase request)
        {
            return new GetMethodOptionsBase
            {
                IncludingErrorCodes = request.IncludingErrorCodes,
                IncludingParameters = request.IncludingParameters,
                IncludingResultType = request.IncludingResultType,
            };
        }

        public static GetMethodOptions WithName(this GetMethodOptionsBase options, string name)
        {
            return new GetMethodOptions(options) { MethodName = name };
        }

        public static GetMethodOptions MapToOptions(this GetMethodRequest request)
        {
            return new GetMethodOptions(request.MapToOptionsBase()) { MethodName = request.Name };
        }
    }
}
