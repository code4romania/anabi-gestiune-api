using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAnabiExceptionResponse(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnabiExceptionHandler>();
        }
    }
}
