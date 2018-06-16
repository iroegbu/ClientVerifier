using ContactVerifierLibrary.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactVerifierCLI.Services.Connections
{
    public class GenerateConnections
    {
        public static List<ContactConnection> PopulateConnections(List<ContactEntity> Contacts, int MaxConnections = 7)
        {
            var connectionsModel = new Helper();
            return connectionsModel.Get(Contacts, MaxConnections).ToList();
        }
    }
}