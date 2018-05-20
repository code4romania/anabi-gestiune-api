using Anabi.Domain;
using Anabi.Features.RecoveryBeneficiaries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.RecoveryBeneficiaries
{
    public class RecoveryBeneficiariesQueryHandler : BaseHandler, IAsyncRequestHandler<GetBeneficiaries, List<Beneficiary>>
    {
        public RecoveryBeneficiariesQueryHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<List<Beneficiary>> Handle(GetBeneficiaries message)
        {
            var command = context.RecoveryBeneficiaries.AsQueryable();

            if (message.Id != null)
            {
                command = command.Where(m => m.Id == message.Id);
            }

            var result = await command.Select(x => new Beneficiary
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return result;
        }
    }
}
