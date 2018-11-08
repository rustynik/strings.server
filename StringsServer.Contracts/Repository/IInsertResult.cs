using System;
using System.Collections.Generic;
using System.Text;

namespace StringsServer.Contracts.Repository
{
    public interface IInsertResult
    {
        bool Inserted { get; }
    }
}
