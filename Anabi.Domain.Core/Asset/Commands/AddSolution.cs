using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Asset.Commands
{
    public class AddSolution : IRequest<int>
    {
        public AddSolution(int assetId)
        {
            AssetId = assetId;
        }

        public int AssetId { get; }


    }
}
