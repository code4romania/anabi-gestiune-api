namespace Anabi.Features.Assets.Models
{
    public class StageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsFinal { get; set; }

        public bool IsRecovery { get; set; }
    }
}
