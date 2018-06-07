using ClientVerifierCLI.Parameters;
using ClientVerifierCLI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Command
{
    interface ICommand
    {
        void SetParameters(IParameter parameter);
        void SetState(object State);
        IResponse Run();
    }
}
