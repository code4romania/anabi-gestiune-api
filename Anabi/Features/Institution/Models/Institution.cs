﻿
using Anabi.Domain.Models;

namespace Anabi.Features.Institution.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string ContactData { get; set; }
    }
}
