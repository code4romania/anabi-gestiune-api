using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.Common.ViewModels;
using Anabi.Features.StorageSpaces.Models;
using MediatR;

namespace Anabi.Features.Assets.Models
{
    public class GetAssetStorageSpace : IRequest<List<StorageSpaceViewModel>>
    {
        public int AssetId { get; set; }
        public StorageSpace StorageSpace { get; set; }


    }
}
