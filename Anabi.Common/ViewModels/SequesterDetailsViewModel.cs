namespace Anabi.Common.ViewModels
{
    public class SequesterDetailsViewModel
    {
        public SequesterDetailsViewModel(int? precautionaryMeasureId)
        {
            PrecautionaryMeasureId = precautionaryMeasureId;
        }

        public int? PrecautionaryMeasureId { get; }
    }
}