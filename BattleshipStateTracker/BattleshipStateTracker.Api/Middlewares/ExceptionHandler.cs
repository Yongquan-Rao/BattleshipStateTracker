using BattleshipStateTracker.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipStateTracker.Api.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            int statusCode;
            switch (exception)
            {
                case BattleshipOverflowException _:
                case BattleshipOverlappedException _:
                case BattleBoardNotFoundException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(
                new ProblemDetails 
                {
                    Instance = context.Request.GetEncodedPathAndQuery(),
                    Status = statusCode,
                    Detail = exception.Message
                }));
        }
    }
}
