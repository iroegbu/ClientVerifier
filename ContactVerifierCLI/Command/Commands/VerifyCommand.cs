using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactVerifierCLI.Parameters;
using ContactVerifierCLI.Response;
using ContactVerifierCLI.Response.Responses;
using ContactVerifierCLI.Services.Search;
using ContactVerifierLibrary.Contact;
using ContactVerifierLibrary.Graph;

namespace ContactVerifierCLI.Command.Commands
{
    class VerifyCommand : ICommand
    {
        private VerifyParameter parameter;
        private List<ContactEntity> Contacts;
        private List<ContactConnection> Connections;

        public IResponse Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var Goal = Contacts.Find(x => x.ContactID == parameter.ContactID);
            var service = new FindContactPath(Contacts, Connections);
            var result = service.Search(Goal);
            watch.Stop();

            return new VerifyResponse()
            {
                ResponseMessage = $"Search completed.{Environment.NewLine}{BuildPath(result)}",
                Payload = null,
                ResponseTime = watch.Elapsed
            };
        }

        public void SetParameters(IParameter parameter)
        {
            this.parameter = parameter as VerifyParameter;
        }

        public void SetState(object State)
        {
            var _State = State as Dictionary<string, object>;
            Contacts = _State["contacts"] as List<ContactEntity>;
            Connections = _State["connections"] as List<ContactConnection>;
        }

        public string BuildPath(Node<int> GoalNode)
        {
            var sb = new StringBuilder();
            int indx = 0;
            while (GoalNode != null)
            {
                if (indx != 0) { sb.Insert(0, " -> "); }
                sb.Insert(0, $"{GoalNode.Label}({GoalNode.Value})");
                GoalNode = GoalNode.Parent;
                indx++;
            }
            return sb.ToString();
        }
    }
}
