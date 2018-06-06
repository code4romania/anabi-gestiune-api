using System;

namespace Anabi.Common.ViewModels
{
    public class RecoveryCommitteeViewModel
    {
        public RecoveryCommitteeViewModel(DateTime? recoveryCommitteeDesignationDate,
            string recoveryCommitteePresident,
            string recoveryCommitteeMembers)
        {
            RecoveryCommitteeDesignationDate = recoveryCommitteeDesignationDate;
            RecoveryCommitteeMembers = recoveryCommitteeMembers;
            RecoveryCommitteePresident = recoveryCommitteePresident;
        }

        public DateTime? RecoveryCommitteeDesignationDate { get; }

        public string RecoveryCommitteePresident { get; }

        public string RecoveryCommitteeMembers { get; }
    }
}
