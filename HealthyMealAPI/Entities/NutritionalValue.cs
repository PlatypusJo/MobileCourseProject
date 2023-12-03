using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class NutritionalValue
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double Kcal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Amount { get; set; }
        public bool IsDefault { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
        public virtual ICollection<Eating> Eatings { get; } = new List<Eating>();
    }
}
