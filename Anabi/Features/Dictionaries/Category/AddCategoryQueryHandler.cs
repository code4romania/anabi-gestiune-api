using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xModel = Anabi.Domain.Core.Models;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Anabi.DataAccess.Ef.DbModels;

namespace Anabi.Features.Dictionaries.Category
{
    public class AddCategoryQueryHandler : BaseQueryHandler, IAsyncRequestHandler<AddCategoryQuery>
    {
        public AddCategoryQueryHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {

        }

        public async Task Handle(AddCategoryQuery message)
        {
            var newCategory = new CategoryDb();
            
            Mapper.Map(message, newCategory);
            
            context.Categorii.Add(newCategory);

            await context.SaveChangesAsync();

        }
    }
}
