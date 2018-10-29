using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.Domain.Asset.Commands;
using FluentValidation;
using MediatR;

namespace Anabi.Domain.Core.Asset.Commands
{
    public class ModifyAssetAddressRequest : IRequest<AddressViewModel>
    {
        public int CountyId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Building { get; set;}

        public string Stair { get;  set; }

        public string Floor { get; set; }

        public string FlatNo{ get; set; }

        public string Description{ get; set; }
    }
}