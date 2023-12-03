using Microsoft.AspNetCore.Identity;

namespace HealthyMealAPI.Entities
{
    public partial class User : IdentityUser
    {
        public string Sex { get; set; } = null!;
        public double KcalGoal { get; set; }
        public double NormalKcal {  get; set; }
        public virtual ICollection<Product> Products { get; } = new List<Product>();
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Eating> Eatings { get; } = new List<Eating>();
        public virtual ICollection<Menu> Menus { get; } = new List<Menu>();
    }
}
