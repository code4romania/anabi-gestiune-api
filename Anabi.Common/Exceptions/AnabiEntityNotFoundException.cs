using System;

namespace Anabi.Common.Exceptions
{
    public class AnabiEntityNotFoundException : Exception
    {
        public AnabiEntityNotFoundException()
        {
        }

        public AnabiEntityNotFoundException(int id) : base(GetDefaultMessageForId(id))
        {
            
        }

        public AnabiEntityNotFoundException(string message) : base(message)
        {
        }

        private static string GetDefaultMessageForId(int id)
        {
            return $"ENTITY_DOES_NOT_EXIST_{id}";
        }
    }
}
