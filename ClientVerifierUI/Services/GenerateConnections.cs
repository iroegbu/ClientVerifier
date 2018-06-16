using ContactVerifierLibrary.Contact;
using ClientVerifierUI.Models.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientVerifierUI.Services
{
    public class GenerateConnections
    {
        public static List<ContactConnection> PopulateConnections(List<ContactEntity> Contacts, int MaxConnections = 7)
        {
            var connectionsModel = new ConnectionModel();
            return connectionsModel.Get(Contacts, MaxConnections).ToList();
        }
    }
}