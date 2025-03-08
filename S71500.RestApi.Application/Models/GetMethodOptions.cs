namespace S71500.RestApi.Application.Models
{
    public class GetMethodOptions : GetMethodOptionsBase
    {
        public required string MethodName { get; init; }

        public GetMethodOptions() : base()
        {

        }

        public GetMethodOptions(GetMethodOptionsBase withOptions) : base(withOptions)
        {

        }

        public GetMethodOptions(GetMethodOptionsBase withOptions, string methodName) : base(withOptions)
        {
            MethodName = methodName;
        }
    }
}
