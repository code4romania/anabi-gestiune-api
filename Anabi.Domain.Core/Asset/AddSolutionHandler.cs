using Anabi.Domain.Asset.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.Domain.Asset
{
    public class AddSolutionHandler : BaseHandler
        , IAsyncRequestHandler<AddSolution, int>
    {
        public AddSolutionHandler(BaseHandlerNeeds needs) : base(needs)
        {
        }

        public async Task<int> Handle(AddSolution message)
        {
            throw new NotImplementedException();
        }
    }
}
