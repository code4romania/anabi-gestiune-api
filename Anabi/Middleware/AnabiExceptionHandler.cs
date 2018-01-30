using Anabi.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.Middleware
{
    public class AnabiExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AnabiExceptionHandler> _logger;

        public AnabiExceptionHandler(RequestDelegate next, ILogger<AnabiExceptionHandler> logger)
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
                _logger.LogError(ex, "Error");
                await WriteErrorMessage(context, ex);
            }

        }

        private static async Task WriteErrorMessage(HttpContext context, Exception ex)
        {
            var errors = new List<string>() { ex.Message };
            await WriteErrorToContext(context, errors, ex.Message);

        }

        private static async Task WriteDomainModelValidationErrorMessage(HttpContext context, DomainModelValidationException ex)
        {
            var errors = ex.Errors;
            await WriteErrorToContext(context, errors, ex.Message);

        }

        private static async Task WriteErrorToContext(HttpContext context, List<string> errors, string message)
        {
            var errorMessage = JsonConvert.SerializeObject(
                new AnabiExceptionResponse
                {
                    CorrelationId = "",
                    Message = message,
                    Errors = errors 
                }
                );

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errorMessageUtf8 = Encoding.UTF8.GetBytes(errorMessage);
            context.Response.ContentType = "application/json";

            await context.Response.Body.WriteAsync(errorMessageUtf8, 0, errorMessageUtf8.Length).ConfigureAwait(false);
        }
    }
}
