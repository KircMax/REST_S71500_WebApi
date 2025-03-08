using S71500.RestApi.Application.Models;
using Siemens.Simatic.S7.Webserver.API.Enums;

namespace S71500.RestApi.Application.Repositories
{
    public static class CompleteDocumentation
    {
        private static List<ApiMethod> _apiMethodsAndDocumentation = new List<ApiMethod>();

        public static List<ApiMethod> ApiMethodsAndDocumentation
        {
            get
            {
                if (_apiMethodsAndDocumentation.Count == 0)
                {
                    _apiMethodsAndDocumentation = new List<ApiMethod>()
                    {
                        new ApiMethod()
                        {
                            Name = "Api.Login",
                            ErrorCodes = new List<ApiErrorCode>() { (ApiErrorCode)4, (ApiErrorCode)6, (ApiErrorCode)100, (ApiErrorCode)101, (ApiErrorCode)102, (ApiErrorCode)105 },
                            Parameters = new List<ApiRequestOrResponseArgument>()
                            {
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "mode", Required = false, DataType = ApiPlcProgramDataType.String,
                                    Description = "​Login mode. You can use all the modes supported by the ​Api.GetAuthenticationMode​ method, see ​Api.GetAuthenticationMode​.\r\n​If no parameter is used, the query is assumed to be \"​local​\"."
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "user", Required = true, DataType = ApiPlcProgramDataType.String,
                                    Description = "​The user name. The parameter must be specified in the following modes: \"​static​\", \"​disabled​\", \"​local​\" and \"​umc​\"."
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "password", Required = true, DataType = ApiPlcProgramDataType.String,
                                    Description = "​​The current password in plain text, without encryption. The parameter must be specified in the following modes: \"​static​\", \"​disabled​\", \"​local​\" and \"​umc​\"."
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "include_web_application_cookie", Required = false, DataType = ApiPlcProgramDataType.Bool,
                                    Description = "​​This parameter specifies:\r\n" +
                                    "​Whether a \"​web_application_cookie​\" cookie was generated for access to protected web applications\r\n​Whether you want to return the cookie with the response to the successful login"
                                },
                            },
                            ResponseArguments = new List<ApiRequestOrResponseArgument>()
                            {
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "token", Required = true, DataType = ApiPlcProgramDataType.String,
                                    Description = "​​​The token indicates that its holder has successfully authenticated themselves at the Web API.\r\n​The returned token must be passed via the HTTP request header \"​X-Auth-Token​\" in subsequent Web API requirements."
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "web_application_cookie", Required = false, DataType = ApiPlcProgramDataType.String,
                                    Description = "Only present if \"​include_web_application_cookie​\" is \"​true​\".\r\n​The holder of the token has successfully authenticated themselves with the Web API and has authorization to access protected web applications."
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "password_expiration", Required = false, DataType = ApiPlcProgramDataType.Struct,
                                    Description = "Type: ​Api_Login_PasswordExpiration_Response. This object contains information on the expiration of the password, if:\r\n​The \"​local​\" or \"​umc​\" authentication mode is used for the CPU and\r\n​The password policy is activated on the CPU",
                                    SubTypes = new List<ApiRequestOrResponseArgument>()
                                    {
                                        new ApiRequestOrResponseArgument()
                                        {
                                            Name = "timestamp", Required = true, DataType = ApiPlcProgramDataType.String,
                                            Description = "​ISO8601 time stamp as a string in Coordinated Universal Time (UTC)\r\n​Indicates when the user password expires. The accuracy must be specified in seconds.",
                                        },
                                        new ApiRequestOrResponseArgument()
                                        {
                                            Name = "warning", Required = true, DataType = ApiPlcProgramDataType.Bool,
                                            Description = "​​This parameter specifies whether the warning threshold was reached before the password expired.",
                                        },
                                    }
                                },
                                new ApiRequestOrResponseArgument()
                                {
                                    Name = "runtime_timeout", Required = false, DataType = ApiPlcProgramDataType.String,
                                    Description = "​ISO 8601 time span as string\r\n​Time span of inactivity in seconds after which a client application is to perform a logout using the API method ​Api.Logout​."
                                },
                            },
                        }
                    };
                }
                return _apiMethodsAndDocumentation;
            }
        }
    }

    public class InMemoryDocumentationDatabase : IDocumentationDatabase
    {

        public Task<IEnumerable<ApiMethod>> GetApiMethodsAndErrorCodesAsync(IEnumerable<ApiMethod> methods)
        {
            return Task.FromResult(CompleteDocumentation.ApiMethodsAndDocumentation.Where(el => methods.Any(method => method.Name == el.Name)));
        }

        public Task<IEnumerable<ApiMethod>> GetApiMethodsRequestParametersAsync(IEnumerable<ApiMethod> methods)
        {
            return Task.FromResult(CompleteDocumentation.ApiMethodsAndDocumentation.Where(el => methods.Any(method => method.Name == el.Name)));
        }

        public Task<IEnumerable<ApiMethod>> GetApiMethodsResultTypesAsync(IEnumerable<ApiMethod> methods)
        {
            return Task.FromResult(CompleteDocumentation.ApiMethodsAndDocumentation.Where(el => methods.Any(method => method.Name == el.Name)));
        }
    }
}
