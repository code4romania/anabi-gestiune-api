using System.Collections.Generic;

namespace Anabi.Domain.Models
{
    public class File
    {
        public int Id { get; set; }

       
        public FileNumber InitialNumber { get; set; }
        public string InitialFileNumber { get; set; }


        public FileNumber CurrentNumber { get; set; }
        public string CurrentFileNumber { get; set; }

        public List<FileNumber> Numbers { get; set; }      

        public decimal DamageAmount { get; set; }

        public string DamageAmountCurrency { get; set; }

        public string LegalClassification { get; set; }

        public string CriminalField { get; set; }

        public List<Person> Defendants { get; set; }

        public List<Asset> Assets { get; set; }

        public Journal Journal { get; set; }
    }
}
