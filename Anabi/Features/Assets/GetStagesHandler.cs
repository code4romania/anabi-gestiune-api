using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets
{
    public class GetStagesHandler : BaseHandler, IAsyncRequestHandler<GetStages, List<StageViewModel>>
    {
        public GetStagesHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<StageViewModel>> Handle(GetStages message)
        {
            var models = await (context.Stages.OrderBy(s => s.Name)
                         .Select(s => mapper.Map<StageViewModel>(s))
                         ).ToListAsync();

            return models;
        }
    }
}
