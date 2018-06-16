namespace Anabi.Domain.Asset.Commands.Models
{
    public class SequesterDetails
    {
        public SequesterDetails(int? precautionaryMeasureId)
        {
            PrecautionaryMeasureId = precautionaryMeasureId;
        }

        public int? PrecautionaryMeasureId { get; }
    }
}
