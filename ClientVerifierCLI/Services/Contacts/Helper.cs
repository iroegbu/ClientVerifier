using ClientVerifierLibrary.Contact;
using ClientVerifierLibrary.Generators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierCLI.Services.Contacts
{
    class Helper
    {
        public IEnumerable<ContactEntity> Get(int Count)
        {
            var Generator = new ClientVerifierLibrary.Generators.GenerateContacts(Count);

            var FirstNames = GetFirstNamesAsync();
            var LastNames = GetLastNamesAsync();

            return Generator.Generate(FirstNames, LastNames);
        }

        public List<string> GetFirstNamesAsync()
        {
            var Path = Directory.GetCurrentDirectory() + @"/Resources/first_names.json";
            var JSON = LoadFile(Path);

            JsonSerializer serializer = new JsonSerializer();

            return JsonConvert.DeserializeObject<List<string>>(JSON);
        }

        public List<string> GetLastNamesAsync()
        {
            var Path = Directory.GetCurrentDirectory() + @"/Resources/last_names.json";
            var JSON = LoadFile(Path);

            JsonSerializer serializer = new JsonSerializer();

            return JsonConvert.DeserializeObject<List<string>>(JSON);
        }

        private string LoadFile(string Path)
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string JSONString = r.ReadToEnd();
                return JSONString;
            }
        }
    }
}
