using ClientVerifierCLI.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Factories
{
    class ParameterFactory
    {
        public static IParameter GetParameter(string[] args)
        {
            if (args.Count() < 1)
            {
                throw new ArgumentException("Invalid command. Parameters are incomplete.");
            }
            switch (args[0])
            {
                case "contacts":
                    return new ContactsParameter(args);
                case "connections":
                    return new ConnectionsParameter(args);
                default:
                    throw new ArgumentException("Invalid command.");
            }
        }
    }
}
