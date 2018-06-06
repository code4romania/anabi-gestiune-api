using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Person.Commands
{
    public class AddDefendant : AddDefendantRequest, IRequest<DefendantViewModel>
    {
        public int AssetId { get; set; }
    }

    
    public class AddPersonValidator : AbstractValidator<AddDefendant>
    {
        private readonly AnabiContext context;

        public AddPersonValidator(AnabiContext ctx)
        {
            context = ctx;

            RuleFor(p => p.IdNumber).MaximumLength(6).WithMessage(Constants.IDNUMBER_MAX_LENGTH_6);
            RuleFor(p => p.IdSerie).MaximumLength(2).WithMessage(Constants.IDSERIE_MAX_LENGTH_2);

            RuleFor(p => p.Identification).MaximumLength(20).WithMessage(Constants.IDENTIFICATION_MAX_LENGTH_20);
            RuleFor(p => p.Identification).NotEmpty().WithMessage(Constants.IDENTIFICATION_CANNOT_BE_EMPTY);

            RuleFor(p => p.Name).MaximumLength(200).WithMessage(Constants.PERSONNAME_MAX_LENGTH_200);
            RuleFor(p => p.Name).NotEmpty().WithMessage(Constants.PERSONNAME_CANNOT_BE_EMPTY);

            RuleFor(p => p.FirstName).MaximumLength(50).WithMessage(Constants.FIRSTNAME_MAX_LENGTH_50);
            RuleFor(p => p.Nationality).MaximumLength(20).WithMessage(Constants.NATIONALITY_MAX_LENGTH_20);

            RuleFor(p => p.Identification).MustAsync(NotExist).WithMessage(Constants.PERSONIDENTIFICATION_ALREADY_EXISTS);

            RuleFor(p => p.AssetId).MustAsync(AssetIdMustExist).WithMessage(Constants.ASSET_INVALID_ID);
        }

        private async Task<bool> NotExist(string identification, CancellationToken cancellationToken)
        {
            var identificationExists = await context.Persons.AnyAsync(x => x.Identification == identification);
            return !identificationExists;
        }


        private async Task<bool> AssetIdMustExist(int id, CancellationToken cancellationToken)
        {
            var assetExists = await context.Assets.AnyAsync(x => x.Id == id);
            return assetExists;
        }

    }
}
