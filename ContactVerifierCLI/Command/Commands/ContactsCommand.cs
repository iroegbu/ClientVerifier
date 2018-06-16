using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactVerifierCLI.Parameters;
using ContactVerifierCLI.Response;
using ContactVerifierCLI.Response.Responses;
using ContactVerifierCLI.Services.Contacts;
using ContactVerifierLibrary.Contact;

namespace ContactVerifierCLI.Command.Commands
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

        public void SetState(object Nothing)
        {
            //no state before this
        }

        private List<ContactEntity> GetContacts(int NotOfContacts)
        {
            return GenerateContacts.PopulateContacts(NotOfContacts);
        }
    }
}
