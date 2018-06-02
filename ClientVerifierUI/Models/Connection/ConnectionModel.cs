using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientVerifierLibrary.Contact;
using ClientVerifierLibrary.Generators;

namespace ClientVerifierUI.Models.Connection
{
    public class ConnectionModel
    {
        public IEnumerable<ContactConnection> Get(List<ContactEntity> Contacts, int MaxConnections)
        {
            var Generator = new GenerateConnections(MaxConnections);

            return Generator.Generate(Contacts);
        }
    }
}