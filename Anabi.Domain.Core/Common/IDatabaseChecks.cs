using System.Threading;
using System.Threading.Tasks;
using Anabi.Domain.Common.Address;
using Anabi.Domain.Institution.Commands;

namespace Anabi.Domain.Common
{
    public interface IDatabaseChecks
    {
        Task<bool> UserExists(string userCode, CancellationToken cancellationToken);

        bool EmptyAddress(IAddAddress address);

        Task<bool> CountyExists(string countyCode, CancellationToken arg2);
    }
}