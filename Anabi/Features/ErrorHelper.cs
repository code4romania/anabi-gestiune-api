using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anabi.Features
{
    public class ErrorHelper
    {
        public static HttpResponseMessage GenerateErrorResponse(FluentValidation.Results.ValidationResult validationResult, string message)
        {
            var errors = GetErrorMessages(validationResult);

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = errors };

            return response;
        }

        public static string GetErrorMessages(FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = validationResult.Errors.ToList();
            string errorMessages = string.Empty;
            errors.ForEach(e => { errorMessages += e.ErrorMessage; });

            return errorMessages;
        }
    }
}
