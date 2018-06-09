using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Parameters
{
    class ConnectionsParameter : IParameter
    {
        public int NumberOfConnections { get; } = 0;
        public int NumberOfContacts { get; } = 1000;

        public ConnectionsParameter(string[] args)
        {
            if (args.Count() < 2)
            {
                throw new ArgumentException("You need to specify maximum number of connections to be generated for each paring.");
            }
            NumberOfConnections = ParseInteger(args[1]);
            if (args.Count() > 2)
            {
                NumberOfContacts = ParseInteger(args[2]);
            }
        }

        private int ParseInteger(string IntegerString)
        {
            if (int.TryParse(IntegerString, out int TempNumberOfContacts))
            {
                return TempNumberOfContacts;
            }
            else
            {
                return 0;
            }
        }
    }
}
