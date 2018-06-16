using ContactVerifierCLI.Command;
using ContactVerifierCLI.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierCLI.Factories
{
    class CommandFactory
    {
        public static ICommand GetCommand(string[] args)
        {
            if (args.Count() < 1)
            {
                throw new ArgumentException("Invalid command. Parameters are incomplete.");
            }
            switch (args[0])
            {
                case "contacts":
                    return new ContactsCommand();
                case "connections":
                    return new ConnectionsCommand();
                case "list":
                    return new ListCommand();
                default:
                    throw new ArgumentException("Invalid command.");
            }
        }
    }
}
