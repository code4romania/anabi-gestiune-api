using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Security.Models
{
    public class GetPasswordHash : IRequest<string>
    {
        public string Password { get; set; }
    }
}
