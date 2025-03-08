using S71500.RestApi.Application.Database;
using S71500.RestApi.Application.Models;

namespace S71500.RestApi.Application.Repositories
{
    public class DocumentationDatabase : IDocumentationDatabase
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public DocumentationDatabase(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }


        public Task<IEnumerable<ApiMethod>> GetApiMethodsAndErrorCodesAsync(IEnumerable<ApiMethod> methods)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiMethod>> GetApiMethodsRequestParametersAsync(IEnumerable<ApiMethod> methods)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiMethod>> GetApiMethodsResultTypesAsync(IEnumerable<ApiMethod> methods)
        {
            throw new NotImplementedException();
        }
    }
}
