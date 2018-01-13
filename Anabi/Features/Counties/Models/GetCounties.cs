using System.Collections.Generic;
using Anabi.Domain.Models;
using MediatR;

namespace Anabi.Features.Counties.Models
{
    public class GetCounties : IRequest<List<County>>
    {
    }
}
