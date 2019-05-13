using System;

using Newtonsoft.Json;
using Anabi.InstitutionsImporter;
using System.IO;
using System.Collections.Generic;

namespace Anabi.InstitutionsImporter
{
    public static class InstitutionImporter
    {
        private static readonly string INSTITUTION_PATH = Path
            .GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));


        public static List<Institution> Deserialize()
        {
            using (StreamReader streamReader = File.OpenText($@"{INSTITUTION_PATH}{Path.DirectorySeparatorChar}institutions.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                return (List<Institution>)serializer
                    .Deserialize(streamReader, typeof(List<Institution>));
            }
        }        
    }


}
