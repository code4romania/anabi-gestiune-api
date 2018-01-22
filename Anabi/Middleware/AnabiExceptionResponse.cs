using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anabi.Middleware
{
    public class AnabiExceptionResponse
    {
        public string CorrelationId { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

    }
}
