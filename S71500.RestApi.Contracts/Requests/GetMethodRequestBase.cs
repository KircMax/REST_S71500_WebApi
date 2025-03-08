namespace S71500.RestApi.Contracts.Requests
{
    public class GetMethodRequestBase
    {
        public bool IncludingParameters { get; init; } = true;
        public bool IncludingErrorCodes { get; init; } = true;
        public bool IncludingResultType { get; set; } = true;
    }
}
