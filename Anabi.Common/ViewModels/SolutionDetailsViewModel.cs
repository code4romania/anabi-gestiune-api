using System;

namespace Anabi.Common.ViewModels
{
    public class SolutionDetailsViewModel
    {
        public SolutionDetailsViewModel(string source, bool? sentOnEmail, 
            string fileNumber, string fileNumberParquet, DateTime? receivingDate,
            bool? isDefinitive, DateTime? definitiveDate,
            DateTime? sentToAuthoritiesDate,
            int? crimeTypeId,
            string legalBasis
            )
        {
            Source = source;
            SentOnEmail = sentOnEmail;
            FileNumber = fileNumber;
            FileNumberParquet = fileNumberParquet;
            ReceivingDate = receivingDate;
            IsDefinitive = isDefinitive;
            DefinitiveDate = definitiveDate;
            SentToAuthoritiesDate = sentToAuthoritiesDate;
            CrimeTypeId = crimeTypeId;
            LegalBasis = legalBasis;
        }

        public string Source { get; }

        public bool? SentOnEmail { get; }

        public string FileNumber { get; }

        public string FileNumberParquet { get; }

        public DateTime? ReceivingDate { get; }

        public bool? IsDefinitive { get; }

        public DateTime? DefinitiveDate { get; }

        public DateTime? SentToAuthoritiesDate { get; }

        public int? CrimeTypeId { get; }

        public string LegalBasis { get; }
    }
}
