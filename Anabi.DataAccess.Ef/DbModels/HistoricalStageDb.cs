﻿using Anabi.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anabi.DataAccess.Ef.DbModels
{
    [Table("HistoricalStages")]
    public class HistoricalStageDb : BaseEntity
    {
        public int AssetId { get; set; }

        public int StageId { get; set; }

        public int? DecizieId { get; set; }

        public int? InstitutionId { get; set; }

        public virtual AssetDb Asset { get; set; }

        public decimal? EstimatedAmount { get; set; }

        public string EstimatedAmountCurrency { get; set; }

        public virtual StageDb Stage { get; set; }

        public virtual DecisionDb Decision { get; set; }

        public string AssetState { get; set; }

        public virtual PersonDb Person { get; set; }

        public int? OwnerId { get; set; }

        public decimal? ActualValue { get; set; }

        public string ActualValueCurrency { get; set; }

        /// <summary>
        /// Temei juridic
        /// </summary>
        public string LegalBasis { get; set; }

        public string DecisionNumber { get; set; }

        public DateTime DecisionDate { get; set; }

        public virtual InstitutionDb IssuingInstitution { get; set; }

        [MaxLength(500)]
        public string Source { get; set; }

        public bool? SentOnEmail { get; set; }

        [MaxLength(200)]
        public string FileNumber { get; set; }

        [MaxLength(200)]
        public string FileNumberParquet { get; set; }

        public DateTime? ReceivingDate { get; set; }

        public DateTime? DefinitiveDate { get; set; }

        public DateTime? SendToAuthoritiesDate { get; set; }

        public bool? IsDefinitive { get; set; }

        [ForeignKey("CrimeTypes")]
        public int? CrimeTypeId { get; set; }

        [ForeignKey("CrimeTypeId")]
        public virtual CrimeTypeDb CrimeType { get; set; }

        [ForeignKey("PrecautionaryMeasures")]
        public int? PrecautionaryMeasureId { get; set; }

        [ForeignKey("PrecautionaryMeasureId")]
        public virtual PrecautionaryMeasureDb PrecautionaryMeasure { get; set; }

        [ForeignKey("RecoveryBeneficiaries")]
        public int? RecoveryBeneficiaryId { get; set; }

        [ForeignKey("RecoveryBeneficiaryId")]
        public virtual RecoveryBeneficiaryDb RecoveryBeneficiary { get; set; }

        public string RecoveryState { get; set; }

        public DateTime? EvaluationCommitteeDesignationDate { get; set; }

        [MaxLength(200)]
        public string EvaluationCommitteePresident { get; set; }

        public string EvaluationCommittee { get; set; }

        public DateTime? RecoveryCommitteeDesignationDate { get; set; }

        [MaxLength(200)]
        public string RecoveryCommitteePresident { get; set; }

        public string RecoveryCommittee { get; set; }

        public DateTime? LastActivity { get; set; }

        [MaxLength(200)]
        public string PersonResponsible { get; set; }

        [MaxLength(100)]
        public string RecoveryApplicationNumber { get; set; }

        public DateTime? RecoveryApplicationDate { get; set; }

        public RecoveryDocumentType? RecoveryDocumentType { get; set; }

        [MaxLength(200)]
        public string RecoveryIssuingInstitution { get; set; }

    }
}
