using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands.Models
{
    public class EvaluationCommittee
    {
        public EvaluationCommittee(DateTime? evaluationCommitteeDesignationDate,
            string evaluationCommitteePresident,
            string evaluationCommitteeMembers)
        {
            EvaluationCommitteeDesignationDate = evaluationCommitteeDesignationDate;
            EvaluationCommitteePresident = evaluationCommitteePresident;
            EvaluationCommitteeMembers = evaluationCommitteeMembers;
        }

        public DateTime? EvaluationCommitteeDesignationDate { get; }

        [MaxLength(200)]
        public string EvaluationCommitteePresident { get; }

        public string EvaluationCommitteeMembers { get; }
    }
}
