using ClientVerifierCLI.Parameters;
using ClientVerifierCLI.Response;
using ClientVerifierLibrary.Contact;
using ClientVerifierCLI.Services.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientVerifierCLI.Services.Contacts;
using ClientVerifierCLI.Response.Responses;

namespace ClientVerifierCLI.Command.Commands
{
    class ConnectionsCommand : ICommand
    {
        private ConnectionsParameter parameter;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Contacts = GenerateContacts.PopulateContacts(parameter.NumberOfContacts);
            var Connections = GetConnections(Contacts, parameter.NumberOfConnections);
            watch.Stop();

            return new ConnectionsResponse()
            {
                ResponseMessage = $"{parameter.NumberOfContacts}\tContacts generated.{Environment.NewLine}{parameter.NumberOfConnections}\tConnections generated.",
                Payload = Connections,
                ResponseTime = watch.Elapsed
            };
        }

        public void SetParameters(IParameter parameter)
        {
            this.parameter = parameter as ConnectionsParameter;
        }

        public void SetState()
        {
            throw new NotImplementedException();
        }

        private List<ContactConnection> GetConnections(List<ContactEntity> Contacts, int MaxConnections)
        {
            return GenerateConnections.PopulateConnections(Contacts, MaxConnections);
        }
    }
}
