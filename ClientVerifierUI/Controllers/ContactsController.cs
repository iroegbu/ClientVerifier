using ClientVerifierLibrary.Contact;
using ClientVerifierUI.Models.Contact;
using ClientVerifierUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClientVerifierUI.Controllers
{
    public class ContactsController : ApiController
    {
        // GET api/contacts
        public IEnumerable<ContactEntity> Get()
        {
            return GenerateContacts.PopulateContacts(10000);
        }
    }
}
