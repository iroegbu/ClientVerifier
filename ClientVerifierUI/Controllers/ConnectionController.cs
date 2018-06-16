using ContactVerifierLibrary.Contact;
using ClientVerifierUI.Models.Connection;
using ClientVerifierUI.Models.Contact;
using ClientVerifierUI.Services;
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
            return GenerateConnections.PopulateConnections(GenerateContacts.PopulateContacts(1000));
        }
    }
}