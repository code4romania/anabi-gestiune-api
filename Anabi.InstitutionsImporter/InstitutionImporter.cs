using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Anabi.InstitutionsImporter
{
    public static class InstitutionImporter
    {
        public static List<Institution> Deserialize()
        {
            using (StreamReader streamReader = File.OpenText($@"institutions.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                return (List<Institution>)serializer
                    .Deserialize(streamReader, typeof(List<Institution>));
            }
        }        
    }


}
