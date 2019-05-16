using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Anabi.InstitutionsImporter
{
    public static class InstitutionImporter
    {
        private readonly static string SOURCE = "institutions.json";
        public static List<Institution> Deserialize()
        {
            string institutionsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SOURCE);
            using (StreamReader streamReader = File.OpenText(institutionsPath))
            {
                JsonSerializer serializer = new JsonSerializer();

                return (List<Institution>)serializer
                    .Deserialize(streamReader, typeof(List<Institution>));
            }
        }        
    }


}
