using System;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person.Commands;
using AutoMapper;
using MediatR;

namespace Anabi.Domain.Person
{
    public class PersonHandler : BaseHandler, IAsyncRequestHandler<AddDefendant, int>
    {
        public PersonHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<int> Handle(AddDefendant message)
        {
            var personDb = mapper.Map<PersonDb>(message);
            personDb.UserCodeAdd = "pop";
            personDb.AddedDate = DateTime.Now;


            var assetDefendant = new AssetDefendantDb()
            {
                AddedDate = DateTime.Now,
                UserCodeAdd = "pop",
                AssetId = message.AssetId,
                Person = personDb
            };

            context.Persons.Add(personDb);
            context.AssetDefendants.Add(assetDefendant);

            await context.SaveChangesAsync();

            return personDb.Id;

        }
    }
}
