using ContactVerifierLibrary.Contact;
using ContactVerifierLibrary.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierLibrary.Adapter
{
    public class NodeAdapter
    {
        public Node<int> FromContacts(List<ContactEntity> Contacts, List<ContactConnection> Connections, Node<int> ContactParent = null)
        {
            var CurrentNode = new Node<int>();
            if (Contacts.Count > 0)
            {
                foreach (var Contact in Contacts)
                {
                    var ContactConnections = SortConnections(Contact, Connections);
                    Connections.RemoveAll(c => c.Source.Equals(Contact));
                    CurrentNode = new Node<int>()
                    {
                        Value = Contact.ContactID,
                        Label = Contact.ContactName,
                        Cost = Contact.CommuncationFrequency,
                        Heuristics = Contact.Location,
                        Parent = ContactParent
                    };
                    CurrentNode.Children = ContactConnections.Select(n => FromContact(n.Target, Connections, CurrentNode)).ToList();
                    return CurrentNode;
                }
            }
            else
            {
                throw new Exception("Invalid number of elements in list");
            }
            return CurrentNode;
        }

        public Node<int> FromContact(ContactEntity Contact, List<ContactConnection> Connections, Node<int> ContactParent = null)
        {
            var ContactConnections = SortConnections(Contact, Connections);
            Connections.RemoveAll(c => c.Source.Equals(Contact));
            var CurrentNode = new Node<int>()
            {
                Value = Contact.ContactID,
                Label = Contact.ContactName,
                Cost = Contact.CommuncationFrequency,
                Heuristics = Contact.Location,
                Parent = ContactParent
            };
            CurrentNode.Children = ContactConnections.Select(n => FromContact(n.Target, Connections, CurrentNode)).ToList();

            return CurrentNode;
        }

        private IEnumerable<ContactConnection> SortConnections(ContactEntity Contact, List<ContactConnection> Connections)
        {
            return Connections.Where(c => c.Source.Equals(Contact)).ToList();
        }
    }
}
