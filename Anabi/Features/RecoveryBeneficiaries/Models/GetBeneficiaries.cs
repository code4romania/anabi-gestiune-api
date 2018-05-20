using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.RecoveryBeneficiaries.Models
{
    public class GetBeneficiaries : IRequest<List<Beneficiary>>
    {
        public int? Id { get; set; }
    }
}
