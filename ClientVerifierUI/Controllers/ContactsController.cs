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

        // GET api/contacts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contacts/5
        public void Delete(int id)
        {
        }
    }
}
