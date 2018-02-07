using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Features.Assets.Models
{
    public class StageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsFinal { get; set; }
    }
}
