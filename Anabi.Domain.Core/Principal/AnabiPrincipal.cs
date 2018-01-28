using Anabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Principal
{
    public class AnabiPrincipal
    {
        public string Email     { get; set; }

        public UserRole Role    { get; set; }
    }
}
