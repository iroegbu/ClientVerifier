using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientVerifierCLI.Parameters;
using ClientVerifierCLI.Response;
using ClientVerifierCLI.Response.Responses;
using ClientVerifierCLI.Services.Contacts;
using ClientVerifierLibrary.Contact;

namespace ClientVerifierCLI.Command.Commands
{
    class ContactsCommand : ICommand
    {
        private ContactsParameter parameter;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Contacts = GetContacts(parameter.NumberOfContacts);
            watch.Stop();

            return new ContactsResponse()
            {
                ResponseMessage = $"{parameter.NumberOfContacts}\tContacts generated",
                Payload = Contacts,
                ResponseTime = watch.Elapsed
            };
        }

        public void SetParameters(IParameter parameter)
        {
            this.parameter = parameter as ContactsParameter;
        }

        public void SetState()
        {
            throw new NotImplementedException();
        }

        private List<ContactEntity> GetContacts(int NotOfContacts)
        {
            return GenerateContacts.PopulateContacts(NotOfContacts);
        }
    }
}
