using Anabi.Common.Exceptions;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Middleware
{
    internal class ValidationPipelineBehavior<TRequest, TResponse> :
                IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> _validators)
        {
            validators = _validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

            if (failures.Any(x => x.ErrorCode == "404"))
            {
                throw new AnabiEntityNotFoundException(string.Join(',', failures.Where(x => x.ErrorCode == "404").Select(f => f.ErrorMessage)));
            }
            else if (failures.Any())
            {
                throw new AnabiValidationException(string.Join(',', failures.Select(f => f.ErrorMessage)));
            }

            return next();
        }
    }
    
}
