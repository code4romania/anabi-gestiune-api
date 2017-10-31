using System.Threading;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using Anabi.Domain.Common.Address;
using Microsoft.EntityFrameworkCore;

namespace Anabi.Domain.Common
{
    public class DatabaseChecks : IDatabaseChecks
    {
        private readonly AnabiContext context;
        private readonly EmptyAddAddressValidator emptyAddAddressValidator;

        public DatabaseChecks(AnabiContext context,
            EmptyAddAddressValidator emptyAddAddressValidator
        )
        {
            this.context = context;
            this.emptyAddAddressValidator = emptyAddAddressValidator;
        }

        public async Task<bool> UserExists(string userCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userCode) || userCode.Length > 20)
            {
                return false;
            }

            return await this.context.Utilizatori.AnyAsync(x => x.UserCode == userCode, cancellationToken);
        }

        public bool EmptyAddress(IAddAddress address)
        {
            var result = this.emptyAddAddressValidator.Validate(address).IsValid;

            return result;
        }

        public async Task<bool> CountyExists(string countyCode, CancellationToken token)
        {
            var r = await this.context.Judete.SingleOrDefaultAsync(x => x.Abreviation == countyCode, token);

            return r != null;
        }
    }
}
