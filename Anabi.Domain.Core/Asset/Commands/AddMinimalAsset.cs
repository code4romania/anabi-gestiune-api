using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Asset.Commands
{
    public class AddMinimalAsset : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string Identifier { get; set; }

        public string UserCode { get; set; }

        public int StageId { get; set; }
    }
}
