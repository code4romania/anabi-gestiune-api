using System;

namespace Anabi.Common.ViewModels
{
    public class EvaluationCommitteeViewModel
    {
        public EvaluationCommitteeViewModel(DateTime? evaluationCommitteeDesignationDate,
            string evaluationCommitteePresident,
            string evaluationCommitteeMembers)
        {
            EvaluationCommitteeDesignationDate = evaluationCommitteeDesignationDate;
            EvaluationCommitteePresident = evaluationCommitteePresident;
            EvaluationCommitteeMembers = evaluationCommitteeMembers;
        }

        public DateTime? EvaluationCommitteeDesignationDate { get; }

        public string EvaluationCommitteePresident { get; }

        public string EvaluationCommitteeMembers { get; }
    }
}
