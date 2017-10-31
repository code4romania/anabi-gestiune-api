namespace Anabi.Domain.Common.Address
{
    public interface IAddAddress
    {
        string CountyCode { get; set; }

        string City { get; set; }

        string Street { get; set; }

        string Building { get; set; }

        string Stair { get; set; }

        string Floor { get; set; }

        string FlatNo { get; set; }
    }
}