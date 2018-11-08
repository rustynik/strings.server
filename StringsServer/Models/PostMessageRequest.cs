using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsServer.Models
{
    public class PostMessageRequest
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string Message { get; set; }
    }
}
