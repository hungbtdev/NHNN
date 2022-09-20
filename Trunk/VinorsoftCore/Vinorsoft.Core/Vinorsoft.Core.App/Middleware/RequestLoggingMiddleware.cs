using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext httpContext, ICoreRequestLogService requestLogService)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex, new string[] { });
            }
            finally
            {

                var routeData = httpContext.GetRouteData();
                if (routeData != null)
                {
                    string controller = routeData.Values["controller"]?.ToString();
                    string action = routeData.Values["action"]?.ToString();
                    string area = routeData.Values["area"]?.ToString();
                    using (var reader = new StreamReader(httpContext.Request.Body))
                    {
                        var requestBody = string.Empty;
                        if (!httpContext.Request.Path.Value.Contains("Login") &&
                           !httpContext.Request.Path.Value.Contains("User") &&
                           !httpContext.Request.Path.Value.Contains("ChangePassword"))
                        {
                            reader.ReadToEnd();
                            if (string.IsNullOrEmpty(requestBody))
                            {
                                if (!string.IsNullOrEmpty(httpContext.Request.ContentType) && httpContext.Request.ContentType.Contains("application/x-www-form-urlencoded"))
                                {
                                    var data = httpContext.Request.Form.Select(d => new
                                    {
                                        d.Key,
                                        d.Value
                                    });
                                    requestBody = JsonConvert.SerializeObject(data);
                                }
                            }
                        }

                        requestLogService.Insert(new Entities.CoreRequestLogs()
                        {
                            Action = action,
                            Area = area,
                            Body = requestBody,
                            Controller = controller,
                            Host = httpContext.Request.Host.Value,
                            FullName = LoginContext.Instance.CurrentUser?.FullName,
                            Id = Guid.NewGuid(),
                            UserName = LoginContext.Instance.CurrentUser?.UserName,
                            Path = httpContext.Request?.Path.Value,
                            StatusCode = httpContext.Response?.StatusCode.ToString(),
                            Method = httpContext.Request?.Method,
                            IsAjaxRequest = httpContext.Request.IsAjaxRequest()
                        });
                    }
                }
            }
        }
    }
}