using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Contact
{
    public class ContactConnection
    {
        public int CommuncationFrequency { get; set; }
        public ContactEntity Source { get; set; }
        public ContactEntity Target { get; set; }
    }
}
