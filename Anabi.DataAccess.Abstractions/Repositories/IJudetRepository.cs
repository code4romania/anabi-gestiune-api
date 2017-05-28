using Anabi.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Abstractions.Repositories
{
    public interface IJudetRepository
    {
        Task<IEnumerable<Judet>> GetJudeteAsync();
        Task<IEnumerable<Judet>> GetJudeteFiltrateAsync(string filtru);

    }
}
