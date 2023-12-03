using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Product
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }
        public string Description { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
    }
}
