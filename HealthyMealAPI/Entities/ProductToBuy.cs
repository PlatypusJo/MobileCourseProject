using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class ProductToBuy
    {
        [Key]
        public string Id { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsBought { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
    }
}
