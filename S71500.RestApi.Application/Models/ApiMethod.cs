using Newtonsoft.Json;
using Siemens.Simatic.S7.Webserver.API.Enums;
using Siemens.Simatic.S7.Webserver.API.Models;

namespace S71500.RestApi.Application.Models
{
    public class ApiMethod
    {
        /// <summary>
        /// Method Name
        /// </summary>
        public required string Name { get; set; }

        public IEnumerable<ApiRequestOrResponseArgument> Parameters { get; set; } = Enumerable.Empty<ApiRequestOrResponseArgument>();
        public IEnumerable<ApiErrorCode> ErrorCodes { get; set; } = Enumerable.Empty<ApiErrorCode>();
        public IEnumerable<ApiRequestOrResponseArgument> ResponseArguments { get; set; } = Enumerable.Empty<ApiRequestOrResponseArgument>();

        public override bool Equals(object? obj)
        {
            return obj is ApiMethod method &&
                   Name == method.Name &&
                   EqualityComparer<IEnumerable<ApiRequestOrResponseArgument>>.Default.Equals(Parameters, method.Parameters) &&
                   EqualityComparer<IEnumerable<ApiErrorCode>>.Default.Equals(ErrorCodes, method.ErrorCodes) &&
                   EqualityComparer<IEnumerable<ApiRequestOrResponseArgument>>.Default.Equals(ResponseArguments, method.ResponseArguments);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Parameters, ErrorCodes, ResponseArguments);
        }

        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public static class ApiMethodMapping
    {
        public static ApiMethod MapToMethod(this ApiClass apiClass)
        {
            return new ApiMethod() { Name = apiClass.Name };
        }
    }

}
