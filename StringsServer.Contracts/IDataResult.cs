using System;
using System.Collections.Generic;
using System.Text;

namespace StringsServer.Contracts
{
    public interface IDataResult<TData> : IResult
    {
        TData Data { get; }
    }
}
