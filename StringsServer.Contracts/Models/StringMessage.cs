using System;
using System.Collections.Generic;
using System.Text;

namespace StringsServer.Contracts.Models
{
    public class StringMessage : IHasId
    {
        public Guid Id { get; set; }

        public string IP { get; set; }

        public string Message { get; set; }
    }
}
