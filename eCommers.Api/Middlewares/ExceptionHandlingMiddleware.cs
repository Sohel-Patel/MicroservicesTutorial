using System.Diagnostics;
using System.Text.RegularExpressions;

namespace eCommers.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }       
            catch (Exception ex)
            {

                // _logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
                // if (ex.InnerException != null)
                // {
                //     _logger.LogError($"{ex.InnerException.GetType().ToString()}:{ex.InnerException.Message}");
                // }

                var stackTrace = new StackTrace(ex, true);
                var frames = stackTrace.GetFrames();

                var userFrame = frames?
                    .FirstOrDefault(f =>
                    {
                        var method = f.GetMethod();
                        var declaringType = method?.DeclaringType;
                        var ns = declaringType?.Namespace ?? string.Empty;
                        return ns.StartsWith("eCommers");
                    });

                if (userFrame != null)
                {
                    var method = userFrame.GetMethod();
                    var declaringType = method?.DeclaringType;
                    string realMethodName = method?.Name ?? "";
                    string declaringTypeName = declaringType?.FullName ?? "UnknownClass";
                    string className = declaringTypeName.Split('+')[0] // removes async state machine suffix
                                .Split('.')
                                .Last();      // gets the class name

                    // Try to extract original async method name from compiler-generated type
                    if (declaringType?.Name.Contains("<") == true)
                    {
                        var match = Regex.Match(declaringType.Name, @"<(?<method>.+?)>d__\d+");
                        if (match.Success)
                        {
                            realMethodName = match.Groups["method"].Value;
                        }
                    }

                    _logger.LogError("Exception in {Class}.{Method}: {Message}", className, realMethodName, ex.Message);
                }
                else
                {
                    _logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);
                }


                // Optional: return a generic error response
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("An unexpected error occurred.");
            
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }


}