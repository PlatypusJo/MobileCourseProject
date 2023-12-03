using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class EatingType
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Eating> Eatings { get; } = new List<Eating>();
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
    }
}
