using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Features.Assets
{
    public class GetCategoriesHandler : BaseHandler, IRequestHandler<GetCategories, List<CategoryViewModel>>
    {
        public GetCategoriesHandler(BaseHandlerNeeds needs) : base(needs)
        {

        }

        public async Task<List<CategoryViewModel>> Handle(GetCategories message, CancellationToken cancellationToken)
        {
            if (message.ParentId != null && message.ParentId <= 0)
            {
                throw new Exception(Constants.INVALID_ID);
            }

            var command = context.Categories
                .Where(c => c.ForEntity == "bun");

            if (message.ParentsOnly == true)
            {
                command = command.Where(c => c.ParentId == null);
            }
            else
            {
                command = command.Where(c => c.ParentId == message.ParentId);
            }

            var models = await command
                .Select(c => mapper.Map<CategoryViewModel>(c))
                .ToListAsync(cancellationToken);

            return models;
        }
    }
}
