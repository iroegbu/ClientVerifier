using ClientVerifierLibrary.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Services.Connections
{
    class Helper
    {
        public IEnumerable<ContactConnection> Get(List<ContactEntity> Contacts, int MaxConnections)
        {
            var Generator = new ClientVerifierLibrary.Generators.GenerateConnections(MaxConnections);

            return Generator.Generate(Contacts);
        }
    }
}
