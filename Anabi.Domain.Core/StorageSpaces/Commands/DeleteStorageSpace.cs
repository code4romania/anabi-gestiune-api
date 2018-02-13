using Anabi.Common.Exceptions;
using Anabi.Common.Utils;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.StorageSpaces.Commands
{
    public class DeleteStorageSpace : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStorageSpaceValidator : AbstractValidator<DeleteStorageSpace>
    {
        private readonly AnabiContext context;

        public DeleteStorageSpaceValidator(AnabiContext _context)
        {
            context = _context;

            RuleFor(c => c.Id).GreaterThan(0).WithMessage(Constants.INVALID_ID);
            RuleFor(c => c).MustAsync(HaveNoReferents).WithMessage(Constants.ENTITY_IS_REFERENCED_BY_OTHER_ENTITIES);
            
        }

        private async Task<bool> HaveNoReferents(DeleteStorageSpace query, CancellationToken arg2)
        {
            var hasReferents = false;

            var storageSpace = await context.StorageSpaces
                .Include(a => a.AssetsStorageSpaces)
                .FirstOrDefaultAsync(c => c.Id == query.Id);

            if (storageSpace == null)
            {
                throw new AnabiEntityNotFoundException(Constants.NO_STORAGE_SPACES_FOUND);
            }

            hasReferents = (
                      (storageSpace.AssetsStorageSpaces == null) ? true : storageSpace.AssetsStorageSpaces.Any()
                     );


            return !hasReferents;
        }
    }
}
