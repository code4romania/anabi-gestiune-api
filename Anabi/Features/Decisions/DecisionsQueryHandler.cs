﻿using Anabi.Domain;
using Anabi.Features.Decisions.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Decisions
{
    public class DecisionsQueryHandler : BaseHandler, IAsyncRequestHandler<GetDecision, List<Decision>>
    {
        public DecisionsQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<Decision>> Handle(GetDecision message)
        {
            var command = context.Decisions.AsQueryable();

            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }

            var result = await command.Select(x => new Decision {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return result;
        }
    }
}
