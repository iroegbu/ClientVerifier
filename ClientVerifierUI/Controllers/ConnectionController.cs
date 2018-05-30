using ClientVerifierLibrary.Contact;
using ClientVerifierUI.Models.Connection;
using ClientVerifierUI.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientVerifierUI.Controllers
{
    public class ConnectionController : ApiController
    {
        // GET api/connection
        public IEnumerable<ContactConnection> Get()
        {
            var connectionsModel = new ConnectionModel();
            var Connections = connectionsModel.Get(PopulateContacts(), 7);
            return Connections;
        }

        private List<ContactEntity> PopulateContacts()
        {
            var contactModel = new ContactModel();
            return contactModel.Get(10000).ToList();
        }
    }
}