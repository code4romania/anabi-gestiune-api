using Anabi.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Abstractions.Repositories
{
    public interface IDosareRepository
    {
        Task<IEnumerable<Dosar>> GetDosareAsync();
    }
}
