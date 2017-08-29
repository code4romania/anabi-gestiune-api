namespace Anabi.Features.Category.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        /// <summary>
        /// Ex: Decision, Asset, Institution
        /// </summary>
        public string ForEntity { get; set; }

    }
}
