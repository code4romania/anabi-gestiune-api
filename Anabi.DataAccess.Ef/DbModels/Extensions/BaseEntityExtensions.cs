using Anabi.Common.ViewModels;

namespace Anabi.DataAccess.Ef.DbModels.Extensions
{
    public static class BaseEntityExtensions
    {
        public static JournalViewModel GetJournalViewModel(this BaseEntity baseEntity)
        {
            return new JournalViewModel
            {
                UserCodeAdd = baseEntity.UserCodeAdd,
                AddedDate = baseEntity.AddedDate,
                UserCodeLastChange = baseEntity.UserCodeLastChange,
                LastChangeDate = baseEntity.LastChangeDate
            };
        }
    }
}
