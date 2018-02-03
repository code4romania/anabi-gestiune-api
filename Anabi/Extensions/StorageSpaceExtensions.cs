using Anabi.Features.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Anabi.Features.StorageSpaces.Models;

namespace Anabi.Extensions
{
    public static class StorageSpaceExtensions
    {

        public static StorageSpaceViewModel ToViewModel(this Anabi.Domain.Models.StorageSpace domainModel)
        {
            var viewModel = new StorageSpaceViewModel();
            Mapper.Map(domainModel, viewModel);
            return viewModel;
        }
    }
}
