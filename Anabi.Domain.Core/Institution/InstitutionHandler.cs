using Anabi.Domain.Common;

namespace Anabi.Domain.Institution
{
    using System.Linq;
    using System;
    using System.Threading.Tasks;

    using Anabi.Domain.Common.Address;
    using Anabi.DataAccess.Ef;
    using Anabi.DataAccess.Ef.DbModels;
    using Anabi.Domain.Institution.Commands;

    using AutoMapper;

    using MediatR;
    using System.Threading;

    public class InstitutionHandler : BaseHandler,
                                      IRequestHandler<DeleteInstitution>,
                                      IRequestHandler<AddInstitution, int>,
                                      IRequestHandler<EditInstitution>
    {

        private readonly IDatabaseChecks checks;

        public InstitutionHandler(BaseHandlerNeeds needs, IDatabaseChecks checks) : base(needs)
        {
            this.checks = checks;
        }

        public async Task<Unit> Handle(DeleteInstitution message, CancellationToken cancellationToken)
        {
            var institution = await this.context.Institutions.FindAsync(message.Id);
            if (institution.AddressId.HasValue)
            {
                await this.DeleteCurrentAddress(institution);
            }
            this.context.Institutions.Remove(institution);
            await this.context.SaveChangesAsync();

            return Unit.Value;
        }

        public async Task<int> Handle(AddInstitution message, CancellationToken cancellationToken)
        {
            var institution = this.mapper.Map<InstitutionDb>(message);
            institution.UserCodeAdd = UserCode();
            institution.AddedDate = DateTime.UtcNow;

            this.context.Institutions.Add(institution);

            if (!this.checks.EmptyAddress(message))
            {
                await SetNewAddressToInstitution(message, institution);
            }

            await this.context.SaveChangesAsync();
            return institution.Id;
        }

        public async Task<Unit> Handle(EditInstitution message, CancellationToken cancellationToken)
        {
            var institution = await this.context.Institutions.FindAsync(message.Id);
            institution.UserCodeLastChange = UserCode();
            institution.LastChangeDate = DateTime.UtcNow;

            this.mapper.Map(message, institution);
            
            await SetNewAddressToInstitution(message, institution);

            await this.context.SaveChangesAsync();
            return Unit.Value;
        }

        private async Task DeleteCurrentAddress(InstitutionDb institution)
        {
            var oldAddressId = institution.AddressId;
            if (oldAddressId.HasValue)
            {
                this.context.Addresses.Remove(
                    await this.context.Addresses.FindAsync(oldAddressId.Value));
            }
        }

        private async Task SetNewAddressToInstitution(IAddAddress message, InstitutionDb institution)
        {
            AddressDb address;
            if (institution.AddressId.HasValue)
            {
                address = await this.context.Addresses.FindAsync(institution.AddressId.Value);
                this.mapper.Map(message, address);
            }
            else
            {
                address = this.mapper.Map<IAddAddress, AddressDb>(message);
            }

            var countyCode = message.CountyCode.ToUpperInvariant();
            address.County = context.Counties.SingleOrDefault(x => x.Abreviation == countyCode);
            institution.Address = address;
        }
    }
}