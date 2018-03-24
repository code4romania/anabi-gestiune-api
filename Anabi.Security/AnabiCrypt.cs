using System;

namespace Anabi.Security
{
    using BCrypt.Net;
    public class AnabiCrypt : IAnabiCrypt
    {
        public bool IsHashCorrespondingToValue(string hash, string value)
        {
            return BCrypt.Verify(value, hash);
        }
    }
}
