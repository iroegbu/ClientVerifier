using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Parameters
{
    class ContactsParameter : IParameter
    {
        public int NumberOfContacts { get; } = 0;

        public ContactsParameter(string[] args)
        {
            if (args.Count() < 2)
            {
                throw new ArgumentException("You need to specify number of contacts to be generated");
            }
            NumberOfContacts = ParseInteger(args[1]);
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
