using ClientVerifierLibrary.Contact;
using ClientVerifierUI.Models.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientVerifierUI.Services
{
    public class GenerateConnections
    {
        public static IEnumerable<ContactConnection> PopulateConnections(List<ContactEntity> Contacts, int MaxConnections = 7)
        {
            var connectionsModel = new ConnectionModel();
            var Connections = connectionsModel.Get(Contacts, MaxConnections);
            return Connections;
        }
    }
}