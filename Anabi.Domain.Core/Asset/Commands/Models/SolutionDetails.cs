using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands.Models
{
    public class SolutionDetails
    {
        public SolutionDetails(string source, bool? sentOnEmail, 
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

        [MaxLength(500)]
        public string Source { get; }

        public bool? SentOnEmail { get; }

        [MaxLength(200)]
        public string FileNumber { get; }

        [MaxLength(200)]
        public string FileNumberParquet { get; }


        public DateTime? ReceivingDate { get; }


        public bool? IsDefinitive { get; }

        public DateTime? DefinitiveDate { get; }


        public DateTime? SentToAuthoritiesDate { get; }



        public int? CrimeTypeId { get; }

        public string LegalBasis { get; }
    }
}
