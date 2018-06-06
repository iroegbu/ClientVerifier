using ClientVerifierCLI.Factories;
using ClientVerifierCLI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter command or help to get help:");
            var input = Console.ReadLine();
            while (input != "exit")
            {
                var ProcessedInput = GetInput(input);
                try
                {
                    var command = CommandFactory.GetCommand(ProcessedInput);
                    var parameter = ParameterFactory.GetParameter(ProcessedInput);
                    command.SetParameters(parameter);
                    var response = command.Run();
                    DisplayOutput(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }
        }

        private static void DisplayOutput(IResponse response)
        {
            Console.WriteLine(response.ResponseMessage());
            Console.WriteLine($"Run time: {response.ResponseTime().TotalMilliseconds} milliseconds");
        }

        private static string[] GetInput(string input)
        {
            return input.Split(' ').ToArray();
        }
    }
}
