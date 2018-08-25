using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.Domain;
using Anabi.Features.Person.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Defendant.Models
{
    public class IdentifierQueryHandler : BaseHandler, IRequestHandler<GetIdentifier, List<Identifier>>
    {
        public IdentifierQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<Identifier>> Handle(GetIdentifier message, CancellationToken cancellationToken)
        {
            var models = await context.Identifiers
                .Where(i => i.IsForPerson == message.IsForPerson)
                .Select(x => mapper.Map<Identifier>(x))
                .ToListAsync(cancellationToken);

            if (models == null || models.Count == 0)
            {
                throw new AnabiEntityNotFoundException(Constants.NO_IDENTIFIERS_FOUND);
            }

            return models;
        }
    }
}
