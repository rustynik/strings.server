using System;
using System.Collections.Generic;
using System.Text;

namespace StringsServer.Contracts
{
    public interface IHasId
    {
        Guid Id { get; }
    }
}
