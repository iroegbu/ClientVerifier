using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientVerifierCLI.Parameters;
using ClientVerifierCLI.Response;
using ClientVerifierCLI.Response.Responses;
using ClientVerifierLibrary.Contact;

namespace ClientVerifierCLI.Command.Commands
{
    class ListCommand : ICommand
    {
        List<ContactEntity> Contacts;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Message = String.Join(Environment.NewLine, Contacts.Select(n => n.ContactName).ToArray());
            watch.Stop();

            IResponse response = new ListResponse()
            {
                ResponseMessage = Message,
                ResponseTime = watch.Elapsed
            };

            return response;
        }

        public void SetParameters(IParameter parameter)
        {
            
        }

        public void SetState(object Contacts)
        {
            this.Contacts = (List<ContactEntity>)Contacts;
        }
    }
}
