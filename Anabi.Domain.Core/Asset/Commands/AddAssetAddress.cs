using Anabi.DataAccess.Ef.DbModels;
using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetAddress : BaseEntity, IRequest<AddressViewModel>
    {
         public int CountyId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set;}

        public string Stair { get;  set; }

        public string Floor { get; set; }

        public string FlatNo{ get; set; }

        public int AssetId{ get; set; }
    }

    //validator
}