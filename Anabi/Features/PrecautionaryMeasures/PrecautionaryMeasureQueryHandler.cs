using Anabi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.PrecautionaryMeasures
{
    public class PrecautionaryMeasureQueryHandler : BaseHandler, IRequestHandler<GetPrecautionaryMeasuresQuery, IEnumerable<MeasuresDictionaryModel>>
    {
        public PrecautionaryMeasureQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<IEnumerable<MeasuresDictionaryModel>> Handle(GetPrecautionaryMeasuresQuery message, CancellationToken cancellationToken)
        {
            return await context.PrecautionaryMeasures.Select(p => new MeasuresDictionaryModel
            {
                Id = p.Id,
                Name = p.Name,
                MeasureType = p.Code
            }).ToListAsync(cancellationToken);
        }
    }
}
