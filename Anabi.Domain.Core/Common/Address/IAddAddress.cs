namespace Anabi.Domain.Common.Address
{
    public interface IAddAddress
    {
        string CountyCode { get; set; }

        string City { get; set; }

        string Street { get; set; }

        string Building { get; set; }

        string Description { get; set; }
    }
}