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
        private List<ContactEntity> Contacts;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Connections = GetConnections(Contacts, parameter.NumberOfConnections);
            watch.Stop();

            return new ConnectionsResponse()
            {
                ResponseMessage = $"{Connections.Count}\tConnections generated.",
                Payload = Connections,
                ResponseTime = watch.Elapsed
            };
        }

        public void SetParameters(IParameter parameter)
        {
            this.parameter = parameter as ConnectionsParameter;
        }

        public void SetState(object Contacts)
        {
            this.Contacts = (List<ContactEntity>)Contacts;
        }

        private List<ContactConnection> GetConnections(List<ContactEntity> Contacts, int MaxConnections)
        {
            return GenerateConnections.PopulateConnections(Contacts, MaxConnections);
        }
    }
}
