using System;
namespace Anabi.Features.Institution.Models
{
    using MediatR;
    using System.Collections.Generic;

    public class GetInstitution : IRequest<List<Institution>>
    {
        public int? Id { get; set; }
    }
}
