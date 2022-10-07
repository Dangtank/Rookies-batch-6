using Middlewares;

namespace Extensions
{
    public static class CustomMiddlewaresExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddlewares>();
        }
    }
}
