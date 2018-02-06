using Anabi.Domain.Exceptions;
using Anabi.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        //public ValidateModelAttribute(ILogger logger)
        //{
        //    _logger = logger;
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.ModelState.IsValid)
                return;

                //_logger.LogWarning("Model validation failed for {@Input} with validation {@Errors}",
                //    context.ActionArguments,
                //    context.ModelState?
                //        .SelectMany(kvp => kvp.Value.Errors)
                //        .Select(e => e.ErrorMessage));
           

            var errors = context.ModelState ?
                    .SelectMany(kvp => kvp.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

            var errorMessage = 
                new AnabiExceptionResponse
                {
                    
                    Message = "Validation Errors",
                    Errors = errors
                }
               ;

            context.Result = new BadRequestObjectResult(errorMessage);
                
            //context.Result = new BadRequestObjectResult(
            //    from kvp in context.ModelState
            //    from e in kvp.Value.Errors
            //    let k = kvp.Key
            //    select new DomainModelValidationException(k.ToString() + e.ErrorMessage) {Errors = errors });
        }

       
    }
}
