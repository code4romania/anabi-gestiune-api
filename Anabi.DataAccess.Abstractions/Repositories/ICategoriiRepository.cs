using Anabi.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Abstractions.Repositories
{
    public interface ICategoriiRepository
    {
        Task<IEnumerable<Categorie>> GetCategoriiAsync();
        Task<IEnumerable<Categorie>> GetCategoriiFiltrateAsync(string filtru);
    }
}
