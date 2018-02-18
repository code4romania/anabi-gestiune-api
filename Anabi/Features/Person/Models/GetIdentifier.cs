using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.Person.Models
{
    public class GetIdentifier : IRequest<List<Identifier>>
    {
        public bool IsForPerson { get; set; }
    }
}
