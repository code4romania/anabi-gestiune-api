namespace Anabi.Domain.Institution
{
    using System;
    using System.Threading.Tasks;

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
        public InstitutionHandler(AnabiContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task Handle(DeleteInstitution message)
        {
            var institution = await this.context.Institutii.FindAsync(message.Id);
            this.context.Institutii.Remove(institution);
            await this.context.SaveChangesAsync();
        }

        public async Task Handle(AddInstitution message)
        {
            var institution = this.mapper.Map<InstitutionDb>(message);
            institution.AddedDate = DateTime.UtcNow;

            this.context.Institutii.Add(institution);
            await this.context.SaveChangesAsync();
        }

        public async Task Handle(EditInstitution message)
        {
            var institution = await this.context.Institutii.FindAsync(message.Id);
            institution.LastChangeDate = DateTime.UtcNow;

            this.mapper.Map(message, institution);

            await this.context.SaveChangesAsync();
        }
    }
}