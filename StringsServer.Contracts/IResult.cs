using System;
using System.Collections.Generic;
using System.Text;

namespace StringsServer.Contracts
{
    public interface IResult
    {
        bool Success { get; }
        string ErrorMessage { get; }
    }
}
