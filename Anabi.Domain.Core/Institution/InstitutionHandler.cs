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

    public class InstitutionHandler : BaseHandler,
                                      IAsyncRequestHandler<DeleteInstitution>,
                                      IAsyncRequestHandler<AddInstitution>,
                                      IAsyncRequestHandler<EditInstitution>
    {

        private readonly IDatabaseChecks checks;

        public InstitutionHandler(AnabiContext context, IMapper mapper, IDatabaseChecks checks) : base(context, mapper)
        {
            this.checks = checks;
        }

        public async Task Handle(DeleteInstitution message)
        {
            var institution = await this.context.Institutii.FindAsync(message.Id);
            if (institution.AddressId.HasValue)
            {
                await this.DeleteCurrentAddress(institution);
            }
            this.context.Institutii.Remove(institution);
            await this.context.SaveChangesAsync();
        }

        public async Task Handle(AddInstitution message)
        {
            var institution = this.mapper.Map<InstitutionDb>(message);
            institution.AddedDate = DateTime.UtcNow;

            this.context.Institutii.Add(institution);

            if (!this.checks.EmptyAddress(message))
            {
                await SetNewAddressToInstitution(message, institution);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task Handle(EditInstitution message)
        {
            var institution = await this.context.Institutii.FindAsync(message.Id);
            institution.LastChangeDate = DateTime.UtcNow;

            this.mapper.Map(message, institution);

            if (this.checks.EmptyAddress(message))
            {
                await DeleteCurrentAddress(institution);
            }
            else
            {
                await SetNewAddressToInstitution(message, institution);
            }

            await this.context.SaveChangesAsync();
        }

        private async Task DeleteCurrentAddress(InstitutionDb institution)
        {
            var oldAddressId = institution.AddressId;
            if (oldAddressId.HasValue)
            {
                this.context.Adrese.Remove(
                    await this.context.Adrese.FindAsync(oldAddressId.Value));
            }
        }

        private async Task SetNewAddressToInstitution(IAddAddress message, InstitutionDb institution)
        {
            AddressDb address;
            if (institution.AddressId.HasValue)
            {
                address = await this.context.Adrese.FindAsync(institution.AddressId.Value);
                this.mapper.Map(message, address);
            }
            else
            {
                address = this.mapper.Map<IAddAddress, AddressDb>(message);
            }

            var countyCode = message.CountyCode.ToUpperInvariant();
            address.County = context.Judete.SingleOrDefault(x => x.Abreviation == countyCode);
            institution.Address = address;
        }
    }
}