using System;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person.Commands;
using MediatR;

namespace Anabi.Domain.Person
{
    public class PersonHandler : BaseHandler, IAsyncRequestHandler<AddDefendant, AddDefendantResponse>
    {
        public PersonHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<AddDefendantResponse> Handle(AddDefendant message)
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
            var response = mapper.Map<AddDefendant, AddDefendantResponse>(message);
            response.Id = personDb.Id;
            response.Journal = new Models.Journal
            {
                AddedDate = personDb.AddedDate,
                UserCodeAdd = personDb.UserCodeAdd,
                LastChangeDate = personDb.LastChangeDate,
                UserCodeLastChange = personDb.UserCodeLastChange,
            };

            return response;

        }
    }
}
