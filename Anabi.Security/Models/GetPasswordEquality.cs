using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Security.Models
{
    public class GetPasswordEquality : IRequest<bool>
    {
        public string HashedPassword { get; set; }

        public string ClearPassword { get; set; }
    }
}
