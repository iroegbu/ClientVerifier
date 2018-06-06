using ClientVerifierLibrary.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientVerifierCLI.Services.Contacts
{
    public class GenerateContacts
    {
        public static List<ContactEntity> PopulateContacts(int Count)
        {
            var helper = new Helper();
            return helper.Get(Count).ToList();
        }
    }
}