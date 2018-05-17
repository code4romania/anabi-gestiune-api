using System;
using System.ComponentModel.DataAnnotations;

namespace Anabi.Domain.Asset.Commands.Models
{
    public class RecoveryCommittee
    {
        public RecoveryCommittee(DateTime? recoveryCommitteeDesignationDate,
            string recoveryCommitteePresident,
            string recoveryCommitteeMembers)
        {
            RecoveryCommitteeDesignationDate = recoveryCommitteeDesignationDate;
            RecoveryCommitteeMembers = recoveryCommitteeMembers;
            RecoveryCommitteePresident = recoveryCommitteePresident;
        }

        public DateTime? RecoveryCommitteeDesignationDate { get; }

        [MaxLength(200)]
        public string RecoveryCommitteePresident { get; }

        public string RecoveryCommitteeMembers { get; }
    }
}
