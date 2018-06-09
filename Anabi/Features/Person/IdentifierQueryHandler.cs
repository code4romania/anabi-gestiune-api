using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Features.Person.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Defendant.Models
{
    public class IdentifierQueryHandler : BaseHandler, IAsyncRequestHandler<GetIdentifier, List<Identifier>>
    {
        public IdentifierQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<Identifier>> Handle(GetIdentifier message)
        {
            var models = await context.Identifiers
                .Where(i => i.IsForPerson == message.IsForPerson)
                .Select(x => mapper.Map<Identifier>(x))
                .ToListAsync();

            if (models == null || models.Count == 0)
            {
                throw new AnabiEntityNotFoundException(Constants.NO_IDENTIFIERS_FOUND);
            }

            return models;
        }
    }
}
