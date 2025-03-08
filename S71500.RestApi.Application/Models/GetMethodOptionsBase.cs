namespace S71500.RestApi.Application.Models
{
    public class GetMethodOptionsBase
    {
        public bool? IncludingParameters { get; set; }
        public bool? IncludingErrorCodes { get; set; }
        public bool? IncludingResultType { get; set; }

        public GetMethodOptionsBase()
        {

        }

        public GetMethodOptionsBase(GetMethodOptionsBase withOptions)
        {
            this.IncludingParameters = withOptions.IncludingParameters;
            this.IncludingErrorCodes = withOptions.IncludingErrorCodes;
            this.IncludingResultType = withOptions.IncludingResultType;
        }
    }
}
