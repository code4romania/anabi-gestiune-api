using System;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Person.Commands;
using MediatR;

namespace Anabi.Domain.Person
{
    public class PersonHandler : BaseHandler, IAsyncRequestHandler<AddDefendant, DefendantViewModel>
    {
        public PersonHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<DefendantViewModel> Handle(AddDefendant message)
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
            var response = mapper.Map<AddDefendant, DefendantViewModel>(message);
            response.Id = personDb.Id;
            response.Journal = new JournalViewModel
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
