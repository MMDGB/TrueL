using Microsoft.AspNetCore.Builder;

namespace Tryplication.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMyPassHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHeaderPass>();
        }
    }
}