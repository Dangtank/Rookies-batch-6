namespace Middlewares
{
    public class CustomMiddlewares
    {
        private readonly RequestDelegate _next;

        public CustomMiddlewares(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;
            string requestInfo =
                "Scheme: "
                + request.Scheme
                + "\r\nHost: "
                + request.Host
                + "\r\nPath: "
                + request.Path
                + "\r\nQueryString: "
                + request.QueryString
                + "\n\rBody: "
                + request.Body;
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (
                StreamWriter outputFile = new StreamWriter(
                    Path.Combine(docPath, "RequestInfo.txt"),
                    true
                )
            )
            {
                outputFile.WriteLine(requestInfo);
            }

            await _next(httpContext);
        }
    }
}
