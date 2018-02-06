using Anabi.Common.Exceptions;
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
            catch (AnabiEntityNotFoundException aex)
            {
                _logger.LogError(aex, "Error");
                await WriteErrorMessage(context, aex, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                await WriteErrorMessage(context, ex, StatusCodes.Status500InternalServerError);
            }

        }

        private static async Task WriteErrorMessage(HttpContext context, Exception ex, int responseCode)
        {
            var errors = new List<string>() { ex.Message };
            await WriteErrorToContext(context, errors, ex.Message, responseCode);

        }

       

        


        private static async Task WriteErrorToContext(HttpContext context, 
            List<string> errors, 
            string message,
            int responseCode)
        {
            var errorMessage = JsonConvert.SerializeObject(
                new AnabiExceptionResponse
                {
                    
                    Message = message,
                    Errors = errors 
                }
                );

            context.Response.StatusCode = responseCode;

            var errorMessageUtf8 = Encoding.UTF8.GetBytes(errorMessage);
            context.Response.ContentType = "application/json";

            await context.Response.Body.WriteAsync(errorMessageUtf8, 0, errorMessageUtf8.Length).ConfigureAwait(false);
        }
    }
}
