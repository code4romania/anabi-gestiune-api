using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Domain.Common.Address
{
    public interface IAddMinimalAddress
    {
        string CountyCode { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string Building { get; set; }
        string Details { get; set; }
    }
}
