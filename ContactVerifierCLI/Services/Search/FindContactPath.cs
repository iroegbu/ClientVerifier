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

        public Node<int> Search(ContactEntity GoalContact)
        {
            var Search = new AStarSearch<int>();
            var Root = Adaptor();
            return Search.Search(Root, ContactToNode(GoalContact));
        }

        private Node<int> Adaptor()
        {
            var Adapter = new NodeAdapter();
            return Adapter.FromContacts(Contacts, Connections);
        }

        private Node<int> ContactToNode(ContactEntity Contact)
        {
            return new Node<int>()
            {
                Value = Contact.ContactID,
                Label = Contact.ContactName,
                Cost = Contact.CommuncationFrequency,
                Heuristics = Contact.Location
            };
        }
    }
}
