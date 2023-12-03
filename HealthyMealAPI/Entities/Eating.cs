using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Eating
    {
        [Key]
        public string Id { get; set; } = null!;
        public string EatingTypeId { get; set; } = null!;
        public string NutritionalValueId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double AmountEaten { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual NutritionalValue NutritionalValue { get; set; } = null!;
        public virtual EatingType EatingType { get; set; } = null!;
    }
}
