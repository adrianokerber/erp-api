using ErpApi.WebAPI.Middlewares;

namespace ErpApi.WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds a Exception handler for the API pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <returns>The IApplicationBuilder"</returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
