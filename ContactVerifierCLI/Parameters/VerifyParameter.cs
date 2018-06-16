using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierCLI.Parameters
{
    class VerifyParameter : IParameter
    {
        public int ContactID { get; } = 0;

        public VerifyParameter(string[] args)
        {
            if (args.Count() < 2)
            {
                throw new ArgumentException("You need to specify maximum number of connections to be generated for each paring.");
            }
            ContactID = ParseInteger(args[1]);
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
