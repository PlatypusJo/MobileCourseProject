using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HealthyMealv1.Models
{
    public class RecipeModel
    {
        public string Id { get; set; }
        public string FoodId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public ObservableCollection<StepModel> StepsCooking { get; set; }
        public ObservableCollection<IngredientModel> Ingredients { get; set; }
    }
}
