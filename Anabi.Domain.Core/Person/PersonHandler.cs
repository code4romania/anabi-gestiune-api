using System;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person.Commands;
using AutoMapper;
using MediatR;

namespace Anabi.Domain.Person
{
    public class PersonHandler : BaseHandler, IAsyncRequestHandler<AddPerson, int>
    {
        public PersonHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<int> Handle(AddPerson message)
        {
            var personDb = mapper.Map<PersonDb>(message);
            personDb.UserCodeAdd = "pop";
            personDb.AddedDate = DateTime.Now;

            context.Persons.Add(personDb);

            await context.SaveChangesAsync();

            return personDb.Id;

        }
    }
}
