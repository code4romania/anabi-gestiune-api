using Anabi.Common.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Anabi.Features.StorageSpaces.Models
{
    public class GetStorageSpace : IRequest<List<StorageSpaceViewModel>>
    {
        public int? Id { get; set; }
    }
}
