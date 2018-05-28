using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using ClientVerifierLibrary.Contact;
using ClientVerifierLibrary.Generators;
using Newtonsoft.Json;

namespace ClientVerifierUI.Models.Contact
{
    public class ContactModel
    {
        public IEnumerable<ContactEntity> Get(int Count)
        {
            var Generator = new GenerateContacts(Count);

            var FirstNames = GetFirstNamesAsync();
            var LastNames = GetLastNamesAsync();

            return Generator.Generate(FirstNames, LastNames);
        }

        public List<string> GetFirstNamesAsync()
        {
            var Path = HostingEnvironment.MapPath("~/App_Data/first_names.json");
            var JSON = LoadFile(Path);

            JsonSerializer serializer = new JsonSerializer();

            return JsonConvert.DeserializeObject<List<string>>(JSON);
        }

        public List<string> GetLastNamesAsync()
        {
            var Path = HostingEnvironment.MapPath("~/App_Data/last_names.json");
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