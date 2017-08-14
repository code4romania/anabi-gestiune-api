using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;

namespace Anabi.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Base")]
    public class BaseController : Controller
    {

        public HttpResponseMessage GenerateErrorResponse(FluentValidation.Results.ValidationResult validationResult, string message)
        {
            var errors = GetErrorMessages(validationResult);
            
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = errors };

            return response;
        }

        public string GetErrorMessages(FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = validationResult.Errors.ToList();
            string errorMessages = string.Empty;
            errors.ForEach(e => { errorMessages += e.ErrorMessage; });

            return errorMessages;
        }

    }
}