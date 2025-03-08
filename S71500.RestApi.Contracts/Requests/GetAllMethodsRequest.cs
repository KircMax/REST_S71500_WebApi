namespace S71500.RestApi.Contracts.Requests
{
    public class GetAllMethodsRequest : GetMethodRequestBase
    {
        public GetAllMethodsRequest()
        {
            IncludingResultType = false;
            IncludingParameters = false;
            IncludingErrorCodes = false;
        }
    }
}
