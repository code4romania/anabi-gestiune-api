using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using FluentValidation;
using MediatR;
using System;

namespace Anabi.Domain.Asset.Commands
{
    public class AddAssetStorageSpace : IRequest<StorageSpaceViewModel>
    {
        public int StorageSpaceId { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
