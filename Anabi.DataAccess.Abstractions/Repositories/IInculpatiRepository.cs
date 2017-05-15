using Anabi.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Abstractions.Repositories
{
    public interface IInculpatiRepository
    {
        Task<IEnumerable<Persoana>> GetInculpatiAsync();
        Task<IEnumerable<Persoana>> GetInculpatiFiltratiAsync(string filtru);
    }
}
