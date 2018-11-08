using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsServer.Models
{
    public class StringMessagesListResponse : ResponseBase
    {
        public IEnumerable<StringMessageModel> Items { get; set; }
    }
}
