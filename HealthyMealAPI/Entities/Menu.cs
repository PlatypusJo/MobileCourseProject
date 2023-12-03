﻿using System.ComponentModel.DataAnnotations;

namespace HealthyMealAPI.Entities
{
    public partial class Menu
    {
        [Key]
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Kcal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
    }
}
