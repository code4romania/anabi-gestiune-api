using System;

using Newtonsoft.Json;
using Anabi.InstitutionsImporter;
using System.IO;
using System.Collections.Generic;

namespace Anabi.InstitutionsImporter
{
    public class InstitutionImporter
    {
        private static readonly string INSTITUTION_PATH = Path
            .GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\.."));

        static List<Institutions> Deserialize()
        {
            using (StreamReader streamReader = File.OpenText($@"{INSTITUTION_PATH}\institutions.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                return (List<Institutions>)serializer
                    .Deserialize(streamReader, typeof(List<Institutions>));
            }
        }

        public List<Institutions> RunImporter() => Deserialize();
    }


}
