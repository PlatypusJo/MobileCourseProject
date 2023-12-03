﻿using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Ingredient
    {
        [Key]
        public string Id { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double Amount { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
    }
}
