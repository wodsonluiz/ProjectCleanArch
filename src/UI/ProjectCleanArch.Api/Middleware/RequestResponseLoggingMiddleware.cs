﻿using Microsoft.AspNetCore.Http;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            FormatRequest(context.Request);

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                await FormatResponse(context.Response);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private void FormatRequest(HttpRequest request)
        {
            _logger.Information(@"[Request] {method}, Host {host} BodyRequest{bodyRequest}",
                request.Method,
                request.Host + request.Path,
                request.QueryString);
        }

        private async Task FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            string body = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            _logger.Information(@"[Response] Status {statuscode} Text:{body}", 
                response.StatusCode, 
                body);
        }
    }
}
