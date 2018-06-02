using ClientVerifierLibrary.Contact;
using ClientVerifierUI.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientVerifierUI.Services
{
    public class GenerateContacts
    {
        public static List<ContactEntity> PopulateContacts(int Count)
        {
            var contactModel = new ContactModel();
            return contactModel.Get(Count).ToList();
        }
    }
}