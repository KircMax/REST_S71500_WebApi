namespace S71500.RestApi
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Methods
        {
            private const string Base = $"{ApiBase}/Methods";

            public const string Get = $"{Base}/{{name}}";
            public const string GetAll = Base;
        }

        public static class WebApps
        {
            private const string Base = $"{ApiBase}/WebApps";

            public const string Get = $"{Base}/{{name}}";
            public const string GetAll = Base;
        }
    }
}
