using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Anabi.Filters
{
    public class AddAuthorizationHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation == null) return;

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            if (!HasAnnonymousAttribute(context))
            {
                var parameter = new NonBodyParameter
                {
                    Description = "The authorization token",
                    In = "header",
                    Name = "Authorization",
                    Required = true,
                    Type = "string"
                };

                operation.Parameters.Add(parameter);
            }
        }

        private bool HasAnnonymousAttribute(OperationFilterContext context)
        {
            return context.ApiDescription.ActionAttributes().Any(x => x is AllowAnonymousAttribute) ||
                   context.ApiDescription.ControllerAttributes().Any(x => x is AllowAnonymousAttribute);
        }
    }
}
