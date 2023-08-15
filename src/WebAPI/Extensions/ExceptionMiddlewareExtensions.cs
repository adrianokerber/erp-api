using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using WebAPI.CustomExceptionMiddleware;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        // Option 1 for handling expcetions on middleware
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Serilog.Log.Error($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }

        // Option 2 for handling expcetions on middleware
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
