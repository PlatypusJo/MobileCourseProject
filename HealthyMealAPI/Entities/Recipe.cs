using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Recipe
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }
        public DateTime CookingTime { get; set; }
        public string Description { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
        public virtual ICollection<CookingStep> CookingSteps { get; } = new List<CookingStep>();
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
    }
}
