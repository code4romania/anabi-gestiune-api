using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class GetStages : IRequest<List<StageViewModel>>
    {
    }
}
