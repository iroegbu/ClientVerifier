using ClientVerifierLibrary.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Generators
{
    public class GenerateConnections
    {
        private int MaxConnections;
        private int MaxCommunicationFrequecy;

        public GenerateConnections(int MaxConnections, int MaxCommunicationFrequecy = 10)
        {
            this.MaxConnections = MaxConnections;
            this.MaxCommunicationFrequecy = MaxCommunicationFrequecy;
        }

        public IEnumerable<ContactConnection> Generate(List<ContactEntity> Contacts)
        {
            var Rand = new Random();

            foreach (var Source in Contacts)
            {
                var Targets = SelectContact(Contacts, Source, Rand.Next(MaxConnections));
                foreach (var _Target in Targets)
                {
                    yield return new ContactConnection()
                    {
                        Source = Source,
                        Target = _Target,
                        CommuncationFrequency = Rand.Next(MaxCommunicationFrequecy)
                    };
                }
            }
        }

        private List<ContactEntity> SelectContact(List<ContactEntity> HayStack, ContactEntity Contact, int Number)
        {
            return HayStack.OrderBy(element => Guid.NewGuid()).Take(Number).ToList();
        }
    }
}
