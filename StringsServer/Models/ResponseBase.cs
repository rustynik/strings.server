using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsServer.Models
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

    }
}
