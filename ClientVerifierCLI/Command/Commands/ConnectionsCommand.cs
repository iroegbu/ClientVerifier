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
            var message = RunChildCommand(parameter.NumberOfContacts);
            var Connections = GetConnections(Contacts, parameter.NumberOfConnections);
            watch.Stop();

            return new ConnectionsResponse()
            {
                ResponseMessage = $"{message}.{Environment.NewLine}{parameter.NumberOfConnections}\tConnections generated.",
                Payload = Connections,
                ResponseTime = watch.Elapsed
            };
        }

        private string RunChildCommand(int NumberOfContacts)
        {
            var ContactsCommand = new ContactsCommand();
            string[] args = { "", parameter.NumberOfContacts.ToString() };
            ContactsParameter contactParameter = new ContactsParameter(args);
            ContactsCommand.SetParameters(contactParameter);
            var response = ContactsCommand.Run();

            Contacts = response.Payload() as List<ContactEntity>;
            return response.ResponseMessage();
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
