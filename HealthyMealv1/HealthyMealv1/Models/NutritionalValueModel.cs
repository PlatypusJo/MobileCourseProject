using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMealv1.Models
{
    public class NutritionalValueModel
    {
        public NutritionalValueModel() { }

        public string Id { get; set; }
        public string FoodId { get; set; }
        public string UnitsId { get; set; }
        public string UnitsName { get; set; }
        public double Kcal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Amount { get; set; }
        public bool IsDefault { get; set; }
    }
}
