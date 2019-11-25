using Anabi.DataAccess.Ef.DbModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Anabi.Validators.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, int> MustBeInDbSet<T, TEntity>(this IRuleBuilder<T, int> ruleBuilder, 
            DbSet<TEntity> dbSet) where TEntity : BaseEntity
        {
            return ruleBuilder.Must(arg =>
            {
                if (arg <= 0)
                {
                    return false;
                }
                var exists = dbSet.Any(x => x.Id == arg);
                return exists;
            });
        }

        public static IRuleBuilderOptions<T, int?> ShouldBeInDbSet<T, TEntity>(this IRuleBuilder<T, int?> ruleBuilder,
            DbSet<TEntity> dbSet) where TEntity : BaseEntity
        {
            return ruleBuilder.Must(arg =>
            {
                if (arg == null)
                {
                    return true;
                }

                if (arg <= 0)
                {
                    return false;
                }

                var exists = dbSet.Any(x => x.Id == arg);
                return exists;
            });
        }

        public static IRuleBuilderOptions<T, TProperty> With404CodeAndErrorMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder,
            string message)
        {
            return ruleBuilder.WithMessage(message).WithErrorCode("404");
        }
    }
}
