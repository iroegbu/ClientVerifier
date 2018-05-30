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
            
            foreach(var Source in Contacts)
            {
                Contacts.Remove(Source);
                ContactEntity[] _Contacts = new ContactEntity[Contacts.Count];
                Contacts.CopyTo(_Contacts);
                var ConnectionCount = Rand.Next(MaxConnections);
                for (var i = 0; i < ConnectionCount; i++)
                {
                    yield return new ContactConnection()
                    {
                        Source = Source,
                        Target = _Contacts.ElementAt(Rand.Next()),
                        CommuncationFrequency = Rand.Next(MaxCommunicationFrequecy)
                    };
                }
                
            }
        }
    }
}
