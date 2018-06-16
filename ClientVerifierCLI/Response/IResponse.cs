using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierCLI.Response
{
    interface IResponse
    {
        TimeSpan ResponseTime();
        string ResponseMessage();
        object Payload();
    }
}
