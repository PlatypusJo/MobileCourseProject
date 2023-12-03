using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class MenuString
    {
        [Key]
        public string Id { get; set; } = null!;
        public string EatingTypeId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string MenuId { get; set; } = null!;

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Menu Menu { get; set; } = null!;
        public virtual EatingType EatingType { get; set; } = null!;
    }
}
