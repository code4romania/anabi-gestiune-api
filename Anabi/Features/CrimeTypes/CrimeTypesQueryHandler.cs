﻿using Anabi.Domain;
using Anabi.Features.CrimeTypes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.CrimeTypes
{
    public class CrimeTypesQueryHandler : BaseHandler, IAsyncRequestHandler<GetCrimeTypes, List<CrimeType>>
    {
        public CrimeTypesQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<CrimeType>> Handle(GetCrimeTypes message)
        {
            var command = context.CrimeTypes.AsQueryable();

            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }

            var result = await command.Select(x => new CrimeType
            {
                Id = x.Id,
                Name = x.CrimeName
            }).ToListAsync();

            return result;
        }
    }
}
