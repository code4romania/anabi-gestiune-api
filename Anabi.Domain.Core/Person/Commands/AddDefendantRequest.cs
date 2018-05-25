﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Person.Commands
{
    public class AddDefendantRequest
    {
        public string IdNumber { get; set; }

        public string IdSerie { get; set; }

        public string Identification { get; set; }

        public bool IsPerson { get; set; }

        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public string FirstName { get; set; }

        public int IdentifierId { get; set; }

        public string Nationality { get; set; }
    }
}
