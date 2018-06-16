using ContactVerifierLibrary.Adapter;
using ContactVerifierLibrary.Contact;
using ContactVerifierLibrary.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierCLI.Services.Search
{
    class FindContactPath
    {
        List<ContactEntity> Contacts;
        List<ContactConnection> Connections;

        public FindContactPath(List<ContactEntity> Contacts, List<ContactConnection> Connections)
        {
            this.Contacts = Contacts;
            this.Connections = Connections;
        }

        public void Search(ContactEntity GoalContact)
        {

        }

        private Node<int> Adaptor()
        {
            var Adapter = new NodeAdapter();
            return Adapter.FromContacts(Contacts, Connections);
        }
    }
}
