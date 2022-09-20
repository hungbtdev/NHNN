using KTApps.Core.App.Context;
using KTApps.Core.LoggingService.Entities;
using KTApps.Core.LoggingService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core.App.Logging
{
    public class ActivityLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IActivityLoggingService activityLoggingService;

        public ActivityLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            try
            {
                activityLoggingService = httpContext.RequestServices.GetRequiredService<IActivityLoggingService>();
                var request = httpContext.Request;
                var stopWatch = Stopwatch.StartNew();
                var requestTime = DateTime.UtcNow;
                var requestBodyContent = await ReadRequestBody(request);
                var originalBodyStream = httpContext.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    var response = httpContext.Response;
                    response.Body = responseBody;
                    await _next(httpContext);
                    stopWatch.Stop();

                    string responseBodyContent = null;
                    responseBodyContent = await ReadResponseBody(response);
                    await responseBody.CopyToAsync(originalBodyStream);
                    var refererUrl = string.Empty;
                    if (request.Headers.ContainsKey("Referer"))
                        refererUrl = string.Format("{0}", request.Headers["Referer"]);
                    await SafeLog(requestTime,
                        stopWatch.ElapsedMilliseconds,
                        response.StatusCode,
                        request.Method,
                        request.Path,
                        request.QueryString.ToString(),
                        requestBodyContent,
                        responseBodyContent,
                        refererUrl);
                }
            }
            catch (Exception ex)
            {
                await _next(httpContext);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task SafeLog(DateTime requestTime,
                            long responseMillis,
                            int statusCode,
                            string method,
                            string path,
                            string queryString,
                            string requestBody,
                            string responseBody,
                            string refererUrl)
        {
            if (path.ToLower().Contains("login", StringComparison.OrdinalIgnoreCase))
            {
                requestBody = "(Request logging disabled for {path})";
                responseBody = "(Response logging disabled for {path})";
            }

            if (path.Equals("/Nav/GetNavigations", StringComparison.OrdinalIgnoreCase) || path.Contains("/Nav/GetNavigations", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            string userName = string.Empty;
            Guid? userId = null;
            if (LoginContext.Instance.CurrentUser != null)
            {
                userName = LoginContext.Instance.CurrentUser.UserName;
                userId = LoginContext.Instance.CurrentUser.UserId;
            }

            await activityLoggingService.SaveAsync(new CoreApiLogItems
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Active = true,
                CreatedBy = userName,
                Deleted = false,
                RequestTime = requestTime,
                ResponseMillis = responseMillis,
                StatusCode = statusCode,
                Method = method,
                Path = path,
                QueryString = queryString,
                RequestBody = requestBody,
                ResponseBody = responseBody,
                UserName = userName,
                UserId = userId,
                RefererUrl = refererUrl
            });
        }
    }
}
