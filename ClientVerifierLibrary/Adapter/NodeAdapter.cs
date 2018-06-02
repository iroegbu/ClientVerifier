using ClientVerifierLibrary.Contact;
using ClientVerifierLibrary.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Adapter
{
    class NodeAdapter
    {
        public Node<int> FromContacts(List<ContactEntity> Contacts, List<ContactConnection> Connections, Node<int> ContactParent = null)
        {
            var CurrentNode = new Node<int>();
            if (Contacts.Count > 0)
            {
                foreach (var Contact in Contacts)
                {
                    var ContactConnections = SortConnections(Contact, Connections);
                    CurrentNode = new Node<int>()
                    {
                        Value = Contact.ContactID,
                        Label = Contact.ContactName,
                        Cost = Contact.CommuncationFrequency,
                        Heuristics = Contact.Location,
                        Parent = ContactParent
                    };
                    CurrentNode.Children = ContactConnections.Select(n => FromContact(n.Source, Connections, CurrentNode)).ToList();
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
            var CurrentNode = new Node<int>()
            {
                Value = Contact.ContactID,
                Label = Contact.ContactName,
                Cost = Contact.CommuncationFrequency,
                Heuristics = Contact.Location,
                Parent = ContactParent
            };
            CurrentNode.Children = ContactConnections.Select(n => FromContact(n.Source, Connections, CurrentNode)).ToList();

            return CurrentNode;
        }

        public List<ContactConnection> SortConnections(ContactEntity Contact, List<ContactConnection> Connections)
        {
            return Connections.Where(c => c.Source.ContactID.Equals(Contact)).ToList();
        }
    }
}
