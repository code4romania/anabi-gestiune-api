namespace Anabi.Security
{
    public interface IAnabiCrypt
    {
        bool IsHashCorrespondingToValue(string hash, string value);
    }
}