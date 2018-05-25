using Anabi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Person.Commands
{
    public class AddDefendantResponse : AddDefendantRequest
    {
        public int DefendantId { get; set; }
        public Journal Journal { get; set; }
    }
}
