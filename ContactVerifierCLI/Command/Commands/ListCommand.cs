using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactVerifierCLI.Parameters;
using ContactVerifierCLI.Response;
using ContactVerifierCLI.Response.Responses;
using ContactVerifierLibrary.Contact;

namespace ContactVerifierCLI.Command.Commands
{
    class ListCommand : ICommand
    {
        List<ContactEntity> Contacts;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Message = String.Join(Environment.NewLine, Contacts.Select(n => $"{n.ContactID.ToString()} \t {n.ContactName}").ToArray());
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
