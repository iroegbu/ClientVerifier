using ClientVerifierLibrary.Adapter;
using ClientVerifierLibrary.Graph;
using ClientVerifierUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientVerifierUI.Controllers
{
    public class GraphController : ApiController
    {
        // GET api/<controller>
        public Node<int> Get()
        {
            var Contacts = GenerateContacts.PopulateContacts(1000);
            var Connections = GenerateConnections.PopulateConnections(Contacts);
            var Adapter = new NodeAdapter();
            var ContactsNode = Adapter.FromContacts(Contacts, Connections);

            return ContactsNode;
            
        }
    }
}