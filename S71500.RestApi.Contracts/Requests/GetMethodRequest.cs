namespace S71500.RestApi.Contracts.Requests
{
    public class GetMethodRequest : GetMethodRequestBase
    {
        public required string Name { get; init; }
    }
}
