using ClientVerifierLibrary.Contact;
using ClientVerifierUI.Models.Contact;
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
            var contactModel = new ContactModel();
            return contactModel.Get(10000);
        }
    }
}
