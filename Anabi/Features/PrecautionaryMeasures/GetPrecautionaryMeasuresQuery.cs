using Anabi.Features.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.PrecautionaryMeasures
{
    public class GetPrecautionaryMeasuresQuery : IRequest<IEnumerable<MeasuresDictionaryModel>>
    {
    }
}
