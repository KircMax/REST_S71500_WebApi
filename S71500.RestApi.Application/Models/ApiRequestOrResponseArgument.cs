using Siemens.Simatic.S7.Webserver.API.Enums;

namespace S71500.RestApi.Application.Models
{
    public class ApiRequestOrResponseArgument
    {
        public required string Name { get; init; }
        public required bool Required { get; init; }
        public required ApiPlcProgramDataType DataType { get; set; }
        public required string Description { get; init; }

        public IEnumerable<ApiRequestOrResponseArgument> SubTypes { get; set; } = Enumerable.Empty<ApiRequestOrResponseArgument>();
    }
}
