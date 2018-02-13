using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.DataAccess.Ef.DbModels
{
    public class UserDb
    {
        public int Id { get; set; }

        public string UserCode { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<FileNumberDb> FilesNumbersAdded { get; set; }
        public virtual ICollection<FileNumberDb> FilesNumbersChanged { get; set; }

        public virtual ICollection<AssetDb> AssetsAdded { get; set; }
        public virtual ICollection<AssetDb> AssetsChanged { get; set; }

        public virtual ICollection<AssetsFileDb> AssetsFileAdded { get; set; }
        public virtual ICollection<AssetsFileDb> AssetsFileChange { get; set; }

        public virtual ICollection<FileDb> FilesAdded { get; set; }
        public virtual ICollection<FileDb> FilesChanged
        {
            get; set;
        }

        public virtual ICollection<HistoricalStageDb> HistoricalStagesAdded { get; set; }
        public virtual ICollection<HistoricalStageDb> HistoricalStagesChanged { get; set; }

        public virtual ICollection<DefendantsFileDb> DefendantFilesAdded { get; set; }
        public virtual ICollection<DefendantsFileDb> DefendantFilesChanged { get; set; }

        public virtual ICollection<InstitutionDb> InstitutionsAdded { get; set; }
        public virtual ICollection<InstitutionDb> InstitutionsChanged { get; set; }

        public virtual ICollection<PersonDb> PersonsAdded { get; set; }
        public virtual ICollection<PersonDb> PersonsChanged { get; set; }

        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpacesAdded { get; set; }
        public virtual ICollection<AssetStorageSpaceDb> AssetsStorageSpacesChanged { get; set; }

        public virtual ICollection<IdentifierDb> IdentifiersAdded { get; set; }
        public virtual ICollection<IdentifierDb> IdentifiersChanged { get; set; }

        public virtual ICollection<AssetDefendantDb> AssetDefendantsAdded { get; set; }
        public virtual ICollection<AssetDefendantDb> AssetDefendantsChanged { get; set; }
    }
}
