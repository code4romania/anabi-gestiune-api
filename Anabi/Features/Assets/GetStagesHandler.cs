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
        public GetStagesHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {

        }

        public async Task<List<StageViewModel>> Handle(GetStages message)
        {
            var models = await (context.Etape.OrderBy(s => s.Name)
                         .Select(s => mapper.Map<StageViewModel>(s))
                         ).ToListAsync();

            return models;
        }
    }
}
