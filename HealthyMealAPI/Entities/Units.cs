using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Units
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<NutritionalValue> NutritionalValues { get; } = new List<NutritionalValue>();
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
        
    }
}
