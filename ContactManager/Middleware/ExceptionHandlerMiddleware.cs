using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ContactManager.API.Middleware
{
    /// <summary>
    /// Exception middleware
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExceptionHandlerMiddleware
    {
        #region private member
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Exception middleware constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex?.ToString(), ex.InnerException);
                await ConvertException(context, ex);
            }
        }

        private static Task ConvertException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string result = string.Empty;

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
